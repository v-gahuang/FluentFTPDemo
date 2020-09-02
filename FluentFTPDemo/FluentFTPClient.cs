using FluentFTP;
using FluentFTPDemo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FluentFTPDemo
{
    public class FluentFTPClient : IFluentFTPClient
    {
		private X509Certificate _x509Certificate;
		private FtpClientConfig _ftpConfig;

		public FluentFTPClient(X509Certificate x509Certificate, FtpClientConfig ftpConfig) 
		{
			_x509Certificate = x509Certificate;
			_ftpConfig = ftpConfig;
		}

		public Task Connect()
        {
            throw new NotImplementedException();
        }

        public async Task<FtpListItem> GetAsync(string ftpFilePath)
        {
			FtpClient client = new FtpClient("123.123.123.123");

			// specify the login credentials, unless you want to use the "anonymous" user account
			client.Credentials = new NetworkCredential("david", "pass123");

			// begin connecting to the server
			await client.ConnectAsync();

			// get a list of files and directories in the "/htdocs" folder
			foreach (FtpListItem item in await client.GetListingAsync(ftpFilePath))
			{

				// if this is a file
				if (item.Type == FtpFileSystemObjectType.File)
				{

					// get the file size
					long size = await client.GetFileSizeAsync(item.FullName);

					// calculate a hash for the file on the server side (default algorithm)
					FtpHash hash = await client.GetChecksumAsync(item.FullName);
				}

				// get modified date/time of the file or folder
				DateTime time = await client.GetModifiedTimeAsync(item.FullName);
			}

			var matchItem = await client.GetListingAsync(ftpFilePath,FtpListOption.SizeModify);
			return matchItem.FirstOrDefault();
		}

		private FtpClient BuildFtpClient(X509Certificate x509Certificate, FtpClientConfig ftpConfig)
		{
			FtpClient client = new FtpClient(ftpConfig.Host, ftpConfig.Port, ftpConfig.User,ftpConfig.Pass);
			client.EncryptionMode = FtpEncryptionMode.Explicit;
			client.SslProtocols = SslProtocols.Tls;
			client.ValidateCertificate += new FtpSslValidation(OnValidateCertificate);
			client.ClientCertificates.Add(x509Certificate);
			void OnValidateCertificate(FtpClient control, FtpSslValidationEventArgs e)
			{
				var cert2 = new X509Certificate2(e.Certificate);
				e.Accept = cert2.Verify();
			}
			return client;
		}


		public async Task GetListingAsync()
		{
			var token = new CancellationToken();
			
			using (var conn = BuildFtpClient(_x509Certificate,_ftpConfig))
			{
				await conn.ConnectAsync(token);

				// get a recursive listing of the files & folders in a specific folder
				foreach (var item in await conn.GetListingAsync("/htdocs", FtpListOption.Recursive, token))
				{
					switch (item.Type)
					{

						case FtpFileSystemObjectType.Directory:

							Console.WriteLine("Directory!  " + item.FullName);
							Console.WriteLine("Modified date:  " + await conn.GetModifiedTimeAsync(item.FullName, FtpDate.Original, token));

							break;

						case FtpFileSystemObjectType.File:

							Console.WriteLine("File!  " + item.FullName);
							Console.WriteLine("File size:  " + await conn.GetFileSizeAsync(item.FullName, token));
							Console.WriteLine("Modified date:  " + await conn.GetModifiedTimeAsync(item.FullName, FtpDate.Original, token));
							Console.WriteLine("Chmod:  " + await conn.GetChmodAsync(item.FullName, token));

							break;

						case FtpFileSystemObjectType.Link:
							break;
					}
				}

			}
		}
	}
}
