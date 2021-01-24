     public void SetText()
        {
            
            if (this.SelectedItems != null)
            {
                StringBuilder displayText = new StringBuilder();
                foreach (ComboItem s in comboItemsCollection)
                {
                    if (s.IsSelected == true && s.Title == Properties.Resources.CHECKALL)
                    {
                        displayText = new StringBuilder();
                        displayText.Append("All");
                        break;
                    }
                    else if (s.IsSelected == true && s.Title != Properties.Resources.CHECKALL)
                    {
                        displayText.Append(s.Title);
                        displayText.Append(',');
                    }
                }
                this.Text = displayText.ToString().TrimEnd(new char[] { ',' });
            }
            // set DefaultText if nothing else selected
            if (string.IsNullOrEmpty(this.Text))
            {
                this.Text = this.DefaultText;  
            }
        }
