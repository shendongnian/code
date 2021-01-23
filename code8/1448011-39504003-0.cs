        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                FileInfo fi = new FileInfo(@"F:\Harris\abc.txt");
                FileStream fs = File.OpenRead(@"F:\Harris\abc.txt");
                using (FileStream compressedFileStream = File.Create(fi.FullName + ".gz"))
                {
                    using (GZipStream compressionStream = new GZipStream(compressedFileStream,
                    System.IO.Compression.CompressionMode.Compress, true))
                    {
                        fs.CopyTo(compressionStream);
                    }
                }//end using
                MessageBox.Show("Done");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { }
        }
        
