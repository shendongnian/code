			byte[] buffer = new byte[bufferSize];
 
			using (var response = (FtpWebResponse)request.GetResponse()) {
				using (var stream = response.GetResponseStream()) {
					using (var fs = new FileStream(dest, FileMode.OpenOrCreate)) {
						int readCount = stream.Read(buffer, 0, bufferSize);
 
						while (readCount > 0) {
                            if (Hash)
                                Console.Write("#");
 
							fs.Write(buffer, 0, readCount);
							readCount = stream.Read(buffer, 0, bufferSize);
						}
                        log.Debug("Download completed for file : " + source);
					}
				}
                log.Debug("Exiting DownloadFile()");
				return response.StatusDescription;
			}
		}
