            string category = dt.Rows[0][14].ToString();
            string[] strCat = category.Split(',');
            for (int i = 0; i < strCat.Length; i++)
            {
                foreach (CheckBox box in panel.Controls.OfType<CheckBox>())
                {
                    if(box.Text == strCat[i])
                    {
                      box.Checked = true; 
                    }
                }
            }
