        /// <summary>
		/// Sends the fileData to the browser and prompts the visitor to save it with the 
        /// name specified in fileName.
		/// </summary>
		/// <param name="defaultFilename">File name to use when browser prompts visitor (spaces will be replaced with dashes)</param>
		/// <param name="data">Data to be sent to visitor's browser</param>
		/// <param name="errorMsg"></param>
		// Mod 08/04/09 Ron C - Reworked code to work right in modern browsers.
		public static bool DownloadToBrowser(string data, string defaultFilename, out string errorMsg){
			errorMsg = "";
			System.Web.HttpResponse response = HttpContext.Current.Response;
			try {
				defaultFilename = defaultFilename.Replace(' ', '-');		//firefox will cut the name off at the space if there is one, so get rid of 'em
				response.Clear();
				response.ContentType = "application/octet-stream";
				response.AddHeader("Content-Disposition", "attachment; filename=" + defaultFilename);
				//8/5/09 Adding a "Content-Length" header was cutting off part of my file.  Apparently
				//       it would need to factor in the length of the headers as well as the conent.
				//       since I have no easy way to figure out the length of the headers, initially I was gonna
				//       eliminate "Content-Length" header.  Doing so works great in IE 7 and FireFox 3, but not 
				//       in Safari 3 or 4(which doesn't download the file without the "Content-Length" header.  So I
				//		 resorted to a cludge of using the header tag and setting it to content length + 1000 for headers.
				//		 I'd love to have a better solution, but his one works and I've already wasted 6+ hours to get to this
				//		 solution.  Cross broswer downloading of a file shouldn't have to be so hard.  -Ron
				int len = data.Length + 1000;
				response.AddHeader("Content-Length", len.ToString()); //file size for progress dialog
				response.Write(data);
				response.Flush();
				response.Close();		//Close() needed to prevent html from page being streamed back after the file data we sent.
				//Don't use response.End() cause it throws a thread abort exception that can't be caught! Actually you can
				//catch it but then it rethrows after the catch block! (What bozo thought that up?).  I found lots of threads on this.
				
			} catch (Exception ex) {
				errorMsg = "Unable to download file to browser.";
				//Add code here to log the error in your environment
				return false;
			}
			return true;
		}
