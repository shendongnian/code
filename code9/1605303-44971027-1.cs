        void ReadFiles()
        {
            try
            {
                DateTime lastScanDate = GetLastScanDate();
                
                SetLastScanDate();
                foreach (string filePath in System.IO.Directory.GetFiles(@"C:\Users\cozogul\Desktop\test"))
                {
                    System.IO.FileInfo fi = new System.IO.FileInfo(filePath);
                    if (fi.CreationTime >= lastScanDate)
                    {
                        //read file
                    }
                    else
                    {
                        //Don't read file.
                    }
                }
            }
            catch (Exception ex)
            {
                //Log your error
            }
        }
        DateTime GetLastScanDate()
        {
            if (System.IO.File.Exists(@"C:\Users\cozogul\Desktop\test\datefile.txt"))
            {
                using (System.IO.FileStream fs = new System.IO.FileStream(@"C:\Users\cozogul\Desktop\test\datefile.txt", System.IO.FileMode.Open))
                {
                    byte[] buffer = new byte[fs.Length];
                    fs.Read(buffer, 0, buffer.Length);
                    string dateString = System.Text.Encoding.UTF8.GetString(buffer);
                    DateTime date = Convert.ToDateTime(dateString);
                    return date;
                }
            }
            //Will read all files.
            else
                return DateTime.MinValue;
        }
        public void SetLastScanDate()
        {
            using (System.IO.FileStream fs = new System.IO.FileStream(@"C:\Users\cozogul\Desktop\test\datefile.txt", System.IO.FileMode.Create))
            {
                byte[] buffer = System.Text.Encoding.UTF8.GetBytes(DateTime.Now.ToString());
                fs.Write(buffer, 0, buffer.Length);
            }
        }
