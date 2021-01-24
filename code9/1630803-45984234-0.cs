            List<string> hafta = new List<string>();
            int total = Int32.Parse(txt_hafta.Text);
            for (int i = 0; i <= total ; i++)
            {
                hafta.Add(i.ToString());                 
              
            }
            cmb_hafta.DataSource = hafta;
