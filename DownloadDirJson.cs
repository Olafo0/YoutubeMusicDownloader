using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoutubeMusicDownloader
{
    public class DownloadDirJson
    {
        public string downloadDirectory { get; set; }

        public DownloadDirJson(string downloadDirectory)
        {
            this.downloadDirectory = downloadDirectory;
        }
    }
}
