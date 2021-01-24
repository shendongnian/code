    private void saveAttemptsStatus()
        {
            try
            {
                var sw = new System.IO.StreamWriter("D:\\AlphaNumDataSum_" + txt_LUsername.Text + "_Attempts");
                foreach (ListViewItem item in list_Count.Items)
                {
                    sw.Write(item + "\r\n");
                }
                sw.Close();
            }
            catch (System.IO.FileNotFoundException ex)
            {
                System.IO.File.Create("D:\\AlphaNumDataSum_" + txt_LUsername.Text + "_Attempts");
                var sw = new System.IO.StreamWriter("D:\\AlphaNumDataSum_" + txt_LUsername.Text + "_Attempts");
                foreach (ListViewItem item in list_Count.Items)
                {
                    sw.Write(item + "\r\n");
                }
                sw.Close();
            }
        }
