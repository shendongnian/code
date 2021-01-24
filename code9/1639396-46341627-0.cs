    public override void AddView(Android.Views.View child)
    {
      child.GetType()?.GetProperty("TopPadding")?.SetValue(child, 0);
      base.AddView(child);
    }
