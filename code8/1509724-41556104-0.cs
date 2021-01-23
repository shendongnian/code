          private void POACheck(object sender, EventArgs e)
            {
                listView2.Items.Clear();
                System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo("Z:/FTPRoot/PDCUpload/POA");            
                var Names = new List<string>();
                foreach (System.IO.FileInfo f in dir.GetFiles("*.*"))
                {
                   if(Names.IndexOf(f.Name) == -1) //-1 result from IndexOf means it's not there.
                    {
                      FlashWindow(this.Handle, true);
                      ListViewItem lSingleItem = listView2.Items.Add(f.Name);
                      using (System.IO.StreamWriter file =
                      new System.IO.StreamWriter(@"C:\Users\sisson.chad\Desktop\POA-MTM.txt", true))
                      {
                       
                           file.WriteLine(f.Name + " - POA Directory - Current Time: " + DateTime.Now.ToString("h:mm:ss tt") + " " + DateTime.Now.ToString("M/d/yyy") + " | Time Received: " + f.LastWriteTime);
                           Names.Add(f.Name);
                      }
                    }
            
                }
            }
                     
        
            
