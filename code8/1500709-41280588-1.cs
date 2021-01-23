        protected void btnLeft_Click(object sender, EventArgs e)
        {
            Move(lstRight, lstLeft);
        }
        protected void btnRight_Click(object sender, EventArgs e)
        {
            Move(lstLeft, lstRight);
        }
        private void Move(ListBox from, ListBox to)
        {
            var selected = from.Items.OfType<ListItem>().Where(x => x.Selected);
            var listItems = selected as ListItem[] ?? selected.ToArray();
            foreach (ListItem item in listItems)
            {
                to.Items.Add(new ListItem(item.Text, item.Value));
            }
            from.ClearSelection();
            foreach (var item in listItems)
            {
                from.Items.Remove(new ListItem(item.Text, item.Value));
            }
        }
