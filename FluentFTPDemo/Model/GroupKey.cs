using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentFTPDemo.Model
{
    public class GroupKey
    {
        public string Host { get; set; }
        public int Port { get; set; }

        public string RemotePath { get; set; }
    }
}
