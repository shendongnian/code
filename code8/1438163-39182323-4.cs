    private void buttonClicked(string listName, string variableValue)
        {
            ListBox l = (ListBox)Controls.Find(listName, true)[0];
            l.Items.Add(variableValue);
            
        }
        private void myButton_Clicked(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            buttonClicked("tutels", b.Name);
            buttonClicked("tutels_AR", b.Text);
        }
