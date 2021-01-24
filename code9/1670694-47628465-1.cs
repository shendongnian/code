        protected void UploadMultipleFiles(object sender, EventArgs e)
        {
            var images = new List<string>();
            foreach (HttpPostedFile postedFile in FileUpload1.PostedFiles)
            {
                string fileName = Path.GetFileName(postedFile.FileName);
                postedFile.SaveAs(Server.MapPath("~/Uploads/") + fileName);
                var imageUrl = "data:image/png;base64," + GetBase64(postedFile.InputStream);
                images.Add(imageUrl);
            }
            rptImages.DataSource = images;
            rptImages.DataBind();
            lblSuccess.Text = string.Format("{0} files have been uploaded successfully.", FileUpload1.PostedFiles.Count);
        }
        private string GetBase64(System.IO.Stream fs)
        {
            System.IO.BinaryReader br = new System.IO.BinaryReader(fs);
            Byte[] bytes = br.ReadBytes((Int32)fs.Length);
            string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
            return base64String;
        }
