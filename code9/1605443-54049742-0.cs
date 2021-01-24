        for (int i = 0; i < lstup.Items.Count; i++)
            {
                if (lstup.Items[i].Selected)
                {
                    if (i > 0 && !lstup.Items[i - 1].Selected)
                    {
                        ListItem bottom = lstup.Items[i];
                       
                        lstup.Items.Remove(bottom);
                        lstup.Items.Insert(i - 1, bottom);
                    }
                }
            }
