    void OnDel(object sender, EventArgs e)
    {
        IDesignerHost designerHost = (IDesignerHost) GetService(typeof(IDesignerHost));
        if (designerHost != null)
        {
            var tab = ((WTab) Component).SelectedTab;
            ((WTab) Component).Controls.Remove(tab);
            designerHost.DestroyComponent(tab);
        }
    }
