using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentFTPDemo.Model
{
    public class FtpClientConfig
    {
        public string Host { get; set; }
        public int Port { get; set; }

        public string User { get; set; }

        public string Pass { get; set; }


        public FtpFileConfig FtpFileConfig { get; set; }


    }

    public class FtpFileConfig
    {
        public string Path { get; set; }
    }
}
