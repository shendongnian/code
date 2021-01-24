    protected void Page_Init(object sender, EventArgs e)
    {
        var data = GetColors();
        var dataByColors = data.ToLookup(c => c.Subject, StringComparer.OrdinalIgnoreCase);
        repColors.DataSource = dataByColors;
        repColors.DataBind();
    }
    protected void repColors_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            var gv = e.Item.FindControl("gvColor") as GridView;
            gv.DataSource = e.Item.DataItem;
            gv.DataBind();
        }
    }
    public class Colors
    {
        public string Text { get; set; }
        public string Subject { get; set; }
    }
    private IEnumerable<Colors> GetColors()
    {
        yield return new Colors { Text = "Color1", Subject = "Blue" };
        yield return new Colors { Text = "Color2", Subject = "Pink" };
        yield return new Colors { Text = "Color3", Subject = "Blue" };
        yield return new Colors { Text = "Color4", Subject = "Red" };
        yield return new Colors { Text = "Color5", Subject = "Pink" };
    }
