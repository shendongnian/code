    private void BindFilter(DropDownList ddl, Func<dynamic, string> getStringAction, IEnumerable<dynamic> items)
        {
            ddl.Items.Clear();
            foreach (var item in items)
            {
                ddl.Items.Add(getStringAction(item));
            }
        }
