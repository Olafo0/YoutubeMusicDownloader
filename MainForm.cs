using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


using YoutubeExplode;
using YoutubeExplode.Converter;
using YoutubeExplode.Videos;
using YoutubeExplode.Videos.Streams;

using NAudio.Wave;
using NAudio.Lame;
using YoutubeExplode.Common;
using AngleSharp.Html;
using YoutubeExplode.Search;
using YoutubeExplode.Playlists;
using AngleSharp.Common;
using System.Windows.Forms.Design;

namespace YoutubeMusicDownloader
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            StartUpInitializer();
        }

        // Uncomment this when deploying project
        //public string userDownloadPath = Path.Combine(Directory.GetParent(Application.StartupPath).FullName, "Download");
        //public string settingsJsonPath = Path.Combine(Directory.GetParent(Application.StartupPath).FullName, "settings.json");

        // To be used in IDE
        // Comment this out when deploying project
        public string userDownloadPath = Path.Combine(Directory.GetParent(Application.StartupPath).Parent.Parent.Parent.FullName, "Download");
        public string settingsJsonPath = Path.Combine(Directory.GetParent(Application.StartupPath).Parent.Parent.Parent.FullName, "settings.json");

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        // Reads the download directory from the settings.json file
        public void StartUpInitializer()
        {
            string settingsJsonString = File.ReadAllText(settingsJsonPath);
            DownloadDirJson settingsInformation = JsonSerializer.Deserialize<DownloadDirJson>(settingsJsonString);

            // If this is the first time using the application it will set up the download directory
            if (settingsInformation.downloadDirectory == "NewInstall")
            {
                settingsInformation.downloadDirectory = userDownloadPath;
                File.WriteAllText(settingsJsonPath, JsonSerializer.Serialize(settingsInformation));
            }

            downloadDirTB.Text = settingsInformation.downloadDirectory;
            formatCB.SelectedIndex = 0;
        }

        // Changes the download directory to whatever the user selected
        private void changeDownloadDirBTN_Click(object sender, EventArgs e)
        {
            using (var folderBrowser = new FolderBrowserDialog())
            {

                if (Directory.Exists(@"C:\") == false)
                {
                    folderBrowser.InitialDirectory = @"D:\";
                }
                else
                {
                    folderBrowser.InitialDirectory = @"C:\";
                }

                folderBrowser.Description = "Select your donwload folder";
                folderBrowser.UseDescriptionForTitle = true;

                if (folderBrowser.ShowDialog() == DialogResult.OK && string.IsNullOrWhiteSpace(folderBrowser.SelectedPath) == false)
                {
                    userDownloadPath = folderBrowser.SelectedPath;
                    downloadDirTB.Text = userDownloadPath;

                    DownloadDirJson newDirectory = new DownloadDirJson(userDownloadPath);
                    File.WriteAllText(settingsJsonPath, JsonSerializer.Serialize(newDirectory));
                }
            }
        }

        // Resets your download directory
        private void resetDirBTN_Click(object sender, EventArgs e)
        {
            userDownloadPath = Path.Combine(Directory.GetParent(Application.StartupPath).Parent.Parent.Parent.FullName, "Download");
            //userDownloadPath = Path.Combine(Directory.GetParent(Application.StartupPath).FullName, "Download");
            downloadDirTB.Text = userDownloadPath;
            DownloadDirJson newDirectory = new DownloadDirJson(userDownloadPath);
            File.WriteAllText(settingsJsonPath, JsonSerializer.Serialize(newDirectory));
        }

        private async void searchVideo_Click(object sender, EventArgs e)
        {
            string userUrl = youtubeUrlTB.Text;

            if (string.IsNullOrEmpty(userUrl))
            {
                MessageBox.Show("No URL entered", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                // If the video requested is a playlist it will fetch all the necesssary data for that
                // Playlist
                if (userUrl.Contains("playlist"))
                {
                    var youtube = new YoutubeClient();
                    isPlaylist = true;
                    try
                    {
                        FetchingPanel.BringToFront();
                        FetchingPanel.Visible = true;

                        var playlistInfo = await youtube.Playlists.GetAsync(userUrl);
                        videoTitle = playlistInfo.Title;
                        videoTitle = string.Join("_", videoTitle.Split(Path.GetInvalidFileNameChars()));
                        currentSongTB.Text = videoTitle;

                        // fetching the data
                        playlistVideo = await youtube.Playlists.GetVideosAsync(userUrl);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    FetchingPanel.Visible = false;
                    downloadBTN.Enabled = true;
                }
                // Video
                else
                {
                    var youtube = new YoutubeClient();

                    // Get metadata
                    try
                    {
                        FetchingPanel.BringToFront();
                        FetchingPanel.Visible = true;
                        var videoInfo = await youtube.Videos.GetAsync(userUrl);
                        videoTitle = videoInfo.Title;
                        videoTitle = string.Join("_", videoTitle.Split(Path.GetInvalidFileNameChars()));
                        currentSongTB.Text = videoTitle;

                        // Get the video streams
                        streamManifest = await youtube.Videos.Streams.GetManifestAsync(userUrl);

                        if (formatCB.SelectedIndex == 0)
                        {
                            HashSet<string?> availableVideoQualities = new HashSet<string?>();
                            // Add all the unique Video quality labels to a list
                            foreach (var item in streamManifest.GetVideoStreams())
                            {
                                var VideoQuality = item.VideoQuality.Label;
                                availableVideoQualities.Add(VideoQuality);
                            }
                            List<int> tempQuality = new List<int>();
                            // Distinguish between the two types of video qualities (p60)
                            foreach (var quality in availableVideoQualities)
                            {
                                if (quality.Contains("p60"))
                                {
                                    int qualityValue = Convert.ToInt32(quality.Remove(quality.Length - 3)) + 1;
                                    tempQuality.Add(qualityValue);
                                }
                                else
                                {
                                    int qualityValue = Convert.ToInt32(quality.Remove(quality.Length - 1));
                                    tempQuality.Add(qualityValue);
                                }
                            }
                            var qualitiesValue = tempQuality.OrderByDescending(x => x);
                            qualityCB.Items.Clear();
                            // Re label them again
                            foreach (var item in qualitiesValue)
                            {
                                if (item == 2161 || item == 1441 || item == 1081 || item == 721)
                                {
                                    qualityCB.Items.Add(item - 1 + "p60");
                                }
                                else
                                {
                                    qualityCB.Items.Add(item + "p");
                                }
                            }
                            qualityLB.Visible = true;
                            qualityCB.Visible = true;
                            qualityCB.Enabled = true;
                            qualityCB.SelectedIndex = 0;
                        }
                        FetchingPanel.Visible = false;
                        downloadBTN.Enabled = true;
                    }
                    catch (Exception ex)
                    {
                        FetchingPanel.Visible = false;
                        MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private IReadOnlyCollection<YoutubeExplode.Playlists.PlaylistVideo> playlistVideo;
        private Boolean isPlaylist;
        //private IAsyncEnumerable<YoutubeExplode.Playlists.PlaylistVideo> playlistVideo;
        private StreamManifest? streamManifest;
        private string videoTitle;
        private CancellationTokenSource cts;

        private async void downloadBTN_Click(object sender, EventArgs e)
        {

            if (isPlaylist == false)
            {
                var youtube = new YoutubeClient();

                cts = new CancellationTokenSource();
                var cancellationToken = cts.Token;


                progressBar.Value = 0;
                progressbarLB.Text = "gathering data";

                downloadPanel.Visible = true;
                downloadPanel.BringToFront();

                // Get the best possible audio stream
                var audioStreamInfo = streamManifest
                    .GetAudioStreams()
                    .GetWithHighestBitrate();


                var progress = new Progress<double>(p =>
                {
                    int progressValue = (int)(p * 100);

                    // Limited to 99 because of some minor errors faced
                    if (progressValue > 99)
                    {
                        progressbarLB.Text = $"{100}%";
                    }
                    else
                    {
                        progressBar.Value = progressValue;
                        progressbarLB.Text = $"{progressValue}%";
                    }

                    if (progressBar.Value >= 99)
                    {
                        progressbarLB.Text = "Done!";
                        okBTN.Enabled = true;
                    }

                });
                //MP 4 format
                if (formatCB.SelectedIndex == 0)
                {
                    try
                    {
                        // Fetch the exact video the user has choosen
                        var videoStreamInfo = streamManifest
                             .GetVideoStreams()
                             .First(s => s.VideoQuality.Label == qualityCB.Text);


                        //Combine them into a single file
                        var streamInfo = new IStreamInfo[] { audioStreamInfo, videoStreamInfo };
                        // Download the video
                        await youtube.Videos.DownloadAsync(streamInfo, new ConversionRequestBuilder($"{userDownloadPath}\\{videoTitle}.mp4").Build(), progress, cancellationToken);
                        streamManifest = null;
                        videoTitle = null;
                        qualityLB.Visible = false;
                        qualityCB.Enabled = false;
                        qualityCB.Visible = false;
                    }
                    catch (OperationCanceledException)
                    {
                        cts.Dispose();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    cts.Dispose();
                }
                //MP 3 format (Audio Only)
                else if (formatCB.SelectedIndex == 1)
                {
                    try
                    {
                        await youtube.Videos.Streams.DownloadAsync(audioStreamInfo, $"{userDownloadPath}\\{videoTitle}_TEMP", progress, cancellationToken);
                        ConverterToMp3($"{userDownloadPath}\\{videoTitle}_TEMP", $"{userDownloadPath}\\{videoTitle}.mp3");
                        File.Delete($"{userDownloadPath}\\{videoTitle}_TEMP");
                        streamManifest = null;
                        videoTitle = null;
                    }
                    catch (OperationCanceledException)
                    {
                        cts.Dispose();
                        File.Delete($"{userDownloadPath}\\{videoTitle}_TEMP");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
            else if (isPlaylist == true)
            {
                var youtube = new YoutubeClient();

                cts = new CancellationTokenSource();
                var cancellationToken = cts.Token;


                int numberOfVideos = playlistVideo.Count;
                int processedVideos = 1;
                progressBar.Value = 0;
                progressbarLB.Text = "gathering data";
                currentProcessLB.Text = $"{processedVideos}/{numberOfVideos}";

                currentProcessLB.Visible = true;
                downloadPanel.Visible = true;
                downloadPanel.BringToFront();


                var progress = new Progress<double>(p =>
                {
                    int progressValue = (int)(p * 100);

                    // Limited to 99 because of some minor errors faced
                    if (progressValue > 99)
                    {
                        progressbarLB.Text = $"{100}%";
                    }
                    else
                    {
                        progressBar.Value = progressValue;
                        progressbarLB.Text = $"{progressValue}%";
                    }

                    if (progressBar.Value >= 99)
                    {
                        progressbarLB.Text = "Done!";
                    }

                });
                if (formatCB.SelectedIndex == 0)
                {
                    
                    string newPlaylistFolder = $"{userDownloadPath}\\{videoTitle}";
                    if (Directory.Exists(newPlaylistFolder) == false)
                    {
                        Directory.CreateDirectory(newPlaylistFolder);
                    }
                    else
                    {
                        int count = 1;
                        string currentAvailableFolder = $"{newPlaylistFolder}{count}";

                        while (Directory.Exists(currentAvailableFolder))
                        {
                            count++;
                            currentAvailableFolder = $"{newPlaylistFolder}{count}";
                        }

                        Directory.CreateDirectory (currentAvailableFolder);
                        newPlaylistFolder = currentAvailableFolder;
                    }


                    try
                    {

                        foreach (var video in playlistVideo)
                        {

                            var streamManifest = await youtube.Videos.Streams.GetManifestAsync(video.Id);
                            string mainVideoName = string.Join("_", video.Title.Split(Path.GetInvalidFileNameChars()));

                            // Incremeant the video proccessed every install
                            currentProcessLB.Text = $"{processedVideos++}/{numberOfVideos}";

                            var audioStreamInfo = streamManifest
                                .GetAudioStreams()
                                .GetWithHighestBitrate();

                            var videoStreamInfo = streamManifest
                                .GetVideoStreams()
                                .OrderByDescending(x => x.VideoQuality)
                                // Get the stream with no greater than 1080p;
                                .First(x => x.VideoResolution.Height <= 1081);


                            var streamInfo = new IStreamInfo[] { audioStreamInfo, videoStreamInfo };
                            await youtube.Videos.DownloadAsync(streamInfo, new ConversionRequestBuilder($"{newPlaylistFolder}\\{mainVideoName}.mp4").Build(), progress, cancellationToken);
                        }
                    }
                    catch (OperationCanceledException)
                    {
                        cts.Dispose();
                        foreach (var video in Directory.GetFiles(newPlaylistFolder))
                        {
                            if (video.Contains($"_TEMP"))
                            {
                                File.Delete(video);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    okBTN.Enabled = true;
                }
                // Audio Format MP3 
                else if (formatCB.SelectedIndex == 1)
                {
                    string newPlaylistFolder = $"{userDownloadPath}\\{videoTitle}";
                    if (Directory.Exists(newPlaylistFolder) == false)
                    {
                        Directory.CreateDirectory(newPlaylistFolder);
                    }
                    else
                    {
                        int count = 1;
                        string currentAvailableFolder = $"{newPlaylistFolder}{count}";

                        while(Directory.Exists(currentAvailableFolder) == true)
                        {
                            count++;
                            currentAvailableFolder = $"{newPlaylistFolder}{count}";
                        }

                        Directory.CreateDirectory(currentAvailableFolder);
                        newPlaylistFolder = currentAvailableFolder;
                    }

                    try
                    {


                        foreach (var video in playlistVideo)
                        {

                            var streamManifest = await youtube.Videos.Streams.GetManifestAsync(video.Id);
                            string mainVideoName = string.Join("_", video.Title.Split(Path.GetInvalidFileNameChars()));

                            currentProcessLB.Text = $"{processedVideos++}/{numberOfVideos}";


                            var audioStreamInfo = streamManifest
                                .GetAudioStreams()
                                .GetWithHighestBitrate();


                            await youtube.Videos.Streams.DownloadAsync(audioStreamInfo, $"{newPlaylistFolder}\\{mainVideoName}_TEMP", progress, cancellationToken);
                            ConverterToMp3($"{newPlaylistFolder}\\{mainVideoName}_TEMP", $"{newPlaylistFolder}\\{mainVideoName}.mp3");
                            File.Delete($"{newPlaylistFolder}\\{mainVideoName}_TEMP");
                        }
                    }
                    catch (OperationCanceledException)
                    {
                        cts.Dispose();

                        foreach (var video in Directory.GetFiles(newPlaylistFolder))
                        {
                            if (video.Contains($"_TEMP"))
                            {
                                File.Delete(video);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                okBTN.Enabled = true;
                isPlaylist = false;
            }
            currentProcessLB.Visible = false;
            downloadBTN.Enabled = false;
            cts.Dispose();
        }

        // A converter is used because it reduces the file size by 90%
        private void ConverterToMp3(string audioFilePath, string audioOutputFile)
        {
            using (var r = new MediaFoundationReader(audioFilePath))
            using (var w = new LameMP3FileWriter(audioOutputFile, r.WaveFormat, LAMEPreset.VBR_90))
            {
                r.CopyTo(w);
                progressbarLB.Text = "DONE!";
            }

        }

        // Cancels the download
        private void cancelBTN_Click(object sender, EventArgs e)
        {
            try
            {
                cts.Cancel();
                MessageBox.Show("Download cancelled", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                downloadPanel.Visible = false;
                okBTN.Enabled = false;
                progressBar.Value = 0;
                progressbarLB.Text = "0%";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void okBTN_Click(object sender, EventArgs e)
        {
            downloadPanel.Visible = false;
            okBTN.Enabled = false;
        }

        private void openFileBTN_Click(object sender, EventArgs e)
        {
            Process.Start(Environment.GetEnvironmentVariable("WINDIR") + @"\explorer.exe", userDownloadPath);
        }

        private void formatCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            downloadBTN.Enabled = false;
            qualityCB.Visible = false;
            qualityCB.Items.Clear();
            qualityLB.Visible = false;
        }

        private void infoBTN_Click(object sender, EventArgs e)
        {
            if (infoPanel.Visible == true)
            {
                infoBTN.Text = "INFO";
                infoPanel.Visible = false;
            }
            else
            {
                infoBTN.Text = "Close INFO";
                infoPanel.Visible = true;
            }
        }
    }
}
