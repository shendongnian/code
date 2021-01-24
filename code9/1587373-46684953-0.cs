    bool firstDone;
    public override void AddView(View child)
    {
        if (firstDone)
        {
            var visualElementRenderer = this as IVisualElementRenderer;
            var element = visualElementRenderer.Element;
            MyMasterDetailPage page = (MyMasterDetailPage)element;
            LayoutParams p = (LayoutParams)child.LayoutParameters;
            p.Width = page.DrawerWidth;
            base.AddView(child, p);
        }
        else
        {
            firstDone = true;
            base.AddView(child);
        }
    }        
}
