        protected void btnUpload_OnClick(object sender, EventArgs e)
        {
            if (fileImport.HasFile)
            {
                UploadProcessFile();
            }
        }
        private void UploadProcessFile()
        {            
            var fileName = fileImport.FileName;
            //Process the rest of your code below you can also assign the file name to your textbox.
        }
 
