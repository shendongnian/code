          //Do something, open a file etc.
          FileStream fs = new FileStream("file.txt", FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
       }
       catch (Exception e)
       {
            System.Windows.MessageBox.Show("Error:" + e.Result + ex.Message);
        }
}`
