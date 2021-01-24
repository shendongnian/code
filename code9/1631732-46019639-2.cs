     void FolderSearch(string sFol)
        {
            try
            {
                foreach (string f in Directory.GetFiles(sFol))
                {
                    listView1.Items.Add(f);
                }
                foreach (string d in Directory.GetDirectories(sFol))
                {                  
                    FolderSearch(d);
                }
            }
            catch (System.Exception excpt)
            {
                MessageBox.Show(excpt.Message);
            }
        }
