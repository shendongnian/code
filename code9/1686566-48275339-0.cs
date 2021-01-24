    System.IO.File.Move expect string paramter.
      
    
        System.Collections.Generic.IEnumerable<string> file = Directory.EnumerateFiles(@"C:\EBMobileSyncService\Error", "*"+date+"?.*", SearchOption.AllDirectories);
            
            if (file.Count() == 1)
            {
                DialogResult retry = MessageBox.Show("Sales " + date + " Transfer Error", "Sales Transfer Error", MessageBoxButtons.RetryCancel);
                if (retry == DialogResult.Retry)
                {
                    System.IO.File.Move(file.First(), "@D:\\EB\\FTP\\EBPOSWMS\\Client\\ECOS\\Export");
                    MessageBox.Show("Sales Moved");
                }
            }
