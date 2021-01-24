         if (File.Exists("D:\\Connect.file"))
            {
                File.Delete("D:\\Connect.file");
            }
            string provider = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=";
            string Security = ";Persist Security Info=False;";
            string con = provider + Location_txtBx.Text + Security;
           StreamWriter sw = new StreamWriter("D:\\Connect.file");
            sw.WriteLine(con);
            sw.Close();
            Location_txtBx.Text = "";
            Acceptbtn.Enabled = false;
