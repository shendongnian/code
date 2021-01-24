        /// <summary>
        /// Function to import local file to dropbox.
        /// </summary>
        public static async Task<bool> WriteFileToDropBox()
        {
            try
            {
                //Connecting with dropbox.
                var file = "File path at dropbox";
                using (var dbx = new DropboxClient("Access Token"))
                using (var fs = new FileStream("Path of file to be uploaded.")
                {
                    var updated = await dbx.Files.UploadAsync(file, WriteMode.Add.Instance, body: fs);
                }
                return true;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
                return false;
            }
        }
