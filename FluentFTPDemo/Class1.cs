using FluentFTP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace FluentFTPDemo
{
    public class Class1
    {
        private FtpClient getFtpsClient(System.Uri uri)
        {
            if (uri.Scheme != "ftps")
            {
                throw new NotImplementedException("Only ftps is implementent");
            }
            var userInfo = uri.UserInfo.Split(':');
            FtpClient client = new FtpClient(uri.Host, userInfo[0], userInfo[1]);
            client.EncryptionMode = FtpEncryptionMode.Explicit;
            client.SslProtocols = SslProtocols.Tls;
            client.ValidateCertificate += new FtpSslValidation(OnValidateCertificate);
            client.Connect();

            void OnValidateCertificate(FtpClient control, FtpSslValidationEventArgs e)
            {
                var cert2 = new X509Certificate2(e.Certificate);
                e.Accept = cert2.Verify();
            }
            return client;
        }
    }
}
