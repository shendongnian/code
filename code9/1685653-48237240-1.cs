    protected void lvCpus_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        if (e.Item.ItemType == ListViewItemType.DataItem)
        {
            var cpu = e.Item.DataItem as Cpu;
            if (cpu == null)
            {
                return;
            }
            var btn = e.Item.FindControl("addToCart") as Button;
            if (btn == null)
            {
                return;
            }
            btn.CommandArgument = cpu.Id.ToString();
            // Set other server-side properties required from code.
        }
    }
