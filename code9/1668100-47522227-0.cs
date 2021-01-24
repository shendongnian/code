      foreach (Control c in this.Controls)
                {
                if (c is RadioButtonList)
                {
                    if (c.ID.Contains("id"))
                    {
                        string FullID = c.ID.ToString();
                    }
                }
                }
