    private void BindMyObjectDropDown()
        {
            ddlMyObject.Items.Clear();
            MyObjectCollection collection = MyObject.GetList(0, true);
            if (collection != null && collection.Count > 0)
            {
                AddDdlItems(collection, 0);
                foreach (ListItem item in ddlMyObject.Items)
                {
                    item.Text = HttpUtility.HtmlDecode(item.Text);
                }
            }
            ddlMyObject.Items.Insert(0, new ListItem(EntityResource.DefaultDropDownPick, "0"));
        }
        private void AddDdlItems(MyObjectCollection collection, int depth)
        {
            string indent = string.Empty;
            for (int i = 0; i < depth; i++)
            {
                indent += _ddlIndent;
            }
            foreach (var myObject in collection)
            {
                ddlMyObject.Items.Add(new ListItem($"{indent}{myObject.Title}", myObject.Id.ToString()));
                if (myObject.Objects!= null && myObject.Objects.Count > 0)
                {
                    AddDdlItems(myObject.Objects, depth + 1);
                }
            }
        }
