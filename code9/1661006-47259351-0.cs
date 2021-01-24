            if (((Button)sender).Parent.Controls.OfType<ComboBox>().Count() > 0)
            {
               foreach(ComboBox C in ((Button)sender).Parent.Controls.OfType<ComboBox>().ToList())
                {
                    if(C.SelectedIndex != -1)
                    {
                        C.SelectedIndexChanged -= this.ComboBox_Promo_SelectedIndexChanged;
                        while (C.SelectedIndex != -1)
                        {
                            C.SelectedIndex = -1;
                        }
                        C.SelectedIndexChanged += this.ComboBox_Promo_SelectedIndexChanged;
                        this.ComboBox_Promo_SelectedIndexChanged(C, EventArgs.Empty);
                    }
                }
            }
