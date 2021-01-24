        private void button1_Click(object sender, RibbonControlEventArgs e)
        {
            Console.Write("Clicked");
            var item = this.Context as Inspector;
            if (item == null)
                return;
            var contactItem = item.CurrentItem as ContactItem;
            if (contactItem != null)
            {
                // current contact on view
                Console.WriteLine(contactItem.BusinessFaxNumber);
            }
        }
