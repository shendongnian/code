    // in the AutoCompleteTextBox itself
        private Form ParentForm
        {
            get
            {
                if (this.Parent != null)
                    return this.Parent.FindForm();
                else
                    return null;
            }
        }
    
        private void UpdateListBoxItems()
        {
            // if there is a ParentForm
            if ((ParentForm != null))
            {
        // this will get the position relative to the form, use instead of this.Location
                Point formposition = this.ParentForm.PointToClient(this.Parent.PointToScreen(this.Location));
                // get its width
                panel.Width = this.Width;
                // calculate the remeining height beneath the TextBox
                panel.Height = this.ParentForm.ClientSize.Height - this.Height - formposition.Y;
                // and the Location to use
                panel.Location = formposition + new Size(0, this.Height);
                // Panel and ListBox have to be added to ParentForm.Controls before calling BingingContext
                if (!this.ParentForm.Controls.Contains(panel))
                {
                    // add the Panel and ListBox to the PartenForm
                    this.ParentForm.Controls.Add(panel);
                }
                ((CurrencyManager)listBox.BindingContext[CurrentAutoCompleteList]).Refresh();
            }
        }
