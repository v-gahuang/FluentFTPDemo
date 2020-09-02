using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentFTPDemo.Model
{
    public static class FtpClientConfigExtensions
    {
        public static string GetGroupKey(this FtpClientConfig ftpClientConfig) 
        {
            string key = $"{ftpClientConfig.Host}#{ftpClientConfig.Port}#{ftpClientConfig.FtpFileConfig.Path}";
            return key;
        }

        public static GroupKey BuildGroup(this FtpClientConfig ftpClientConfig)
        {
            return new GroupKey { Host = ftpClientConfig.Host, Port = ftpClientConfig.Port, RemotePath = ftpClientConfig.FtpFileConfig.Path };
        }

        public static IEnumerable<IGrouping<GroupKey, FtpClientConfig>> BuildGroup(this List<FtpClientConfig> ftpClientConfigs)
        {
            var groups = ftpClientConfigs.GroupBy(f => f.BuildGroup());
            return groups;
        }

        public static void ConsoleGroups(IEnumerable<IGrouping<GroupKey, FtpClientConfig>> ftpClientGroups) 
        {
            
            foreach (IGrouping<GroupKey, FtpClientConfig> group in ftpClientGroups)
            {
                Console.Write("\nBooks in " + group.Key + " category: ");
                foreach (FtpClientConfig config in group)
                {
                    Console.Write(config.Host + " ");
                }
            }
        }
    }
}
