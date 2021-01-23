    Protected void Page_Load(object sender, EventArgs e)
        {
            // You can set the first list item text to empty string as well
            this.ddItems.Items.Add(new ListItem("select an item", ""));
            this.ddItems.Items.Add(new ListItem("first item", "1"));
            this.ddItems.Items.Add(new ListItem("second item", "2"));
            this.ddItems.Items.Add(new ListItem("third item", "3"));
            
            //This is no longer required as the default selected index is 0
            this.ddItems.SelectedIndex = 0;
        }
