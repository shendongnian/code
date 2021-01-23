	internal int Download(string filename, string sourcePath, string localPath, out string message)
    {
        message = string.Empty;
        int download = 0;
        try
        {
            string fullFilename = "ftp://" + host + "/" + sourcePath + "/" + filename;
            if (!FileExists(fullFilename))
            {
                message = string.Format("Bestand {0} niet gevonden.", fullFilename);
                download = 1;
            }
			else
			{
				ftpRequest = (FtpWebRequest)FtpWebRequest.Create(fullFilename);
				ftpRequest.Credentials = new NetworkCredential(username, password);
				ftpRequest.UseBinary = true;
				ftpRequest.UsePassive = true;
				ftpRequest.KeepAlive = false;
				ftpRequest.Method = WebRequestMethods.Ftp.DownloadFile;
		 
				string tempFilename = Path.Combine(localPath, filename);
				ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
				Stream responseStream = ftpResponse.GetResponseStream();
				FileStream fileStream = new FileStream(tempFilename, fileMode.Create);
				int length = 2048;
				Byte[] buffer = new Byte[length];
				int bytesRead = responseStream.Read(buffer, 0, length);
				while (bytesRead > 0)
				{
					fileStream.Write(buffer, 0, bytesRead);
					bytesRead = responseStream.Read(buffer, 0, length);
				}
				fileStream.Close();
				responseStream.Close();            
			}
		}	
        catch (WebException ex)
        {
            //Console.WriteLine("Upload File Complete, status {0}", ftpResponse.StatusDescription);
            message = ((FtpWebResponse)ex.Response).StatusDescription;
            download = 2;
        }
        catch (Exception ex)
        {
            message = ex.Message;
            download = 3;
        }
        finally
        {
            /* Resource Cleanup */
            if (ftpResponse != null) ftpResponse.Close();
            if (ftpRequest != null) ftpRequest = null;
        }
        return download;
    }
