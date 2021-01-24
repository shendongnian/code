    private void saveAttemptsStatus()
        {    
            var filePath = "D:\\AlphaNumDataSum_" + txt_LUsername.Text;
       
            using(sw = new System.IO.StreamWriter(filePath)){
                foreach (ListViewItem item in list_Count.Items)
                {
                  sw.WriteLine(item.Text);               
                }
            }   
        }
