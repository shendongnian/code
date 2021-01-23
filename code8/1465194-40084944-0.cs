            foreach (ListItem item in rdlUser.Items)
            {
                if (item.Text == "Normal User")
                {
                    item.Attributes.Add("class", "NormalUser");
                }
                else
                {
                    item.Attributes.Add("class", "SpecialUser");
                }
            }
