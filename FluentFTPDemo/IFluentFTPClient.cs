using FluentFTP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentFTPDemo
{
    public interface IFluentFTPClient
    {
        Task Connect();

        Task<FtpListItem> GetAsync(string ftpFilePath);
    }
}
