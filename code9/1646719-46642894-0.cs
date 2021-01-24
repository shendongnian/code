			var request = createRequest(WebRequestMethods.Ftp.ListDirectory);
			
			using (var response = (FtpWebResponse)request.GetResponse()) {
				using (var stream = response.GetResponseStream()) {
					using (var reader = new StreamReader(stream, true)) {
						while (!reader.EndOfStream) {
							list.Add(reader.ReadLine());
						}
					}
				}
			}
 
			return list.ToArray();
		}
