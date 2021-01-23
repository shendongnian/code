    protected override void OnMeasureItem(MeasureItemEventArgs e)
    {
        if (e.Index >= 0 && e.Index < Items.Count) {
            var item = (MyItemType)Items[e.Index];
            e.ItemHeight = Math.Max(15, item.GetThumbnailHeight());
        }
    }
