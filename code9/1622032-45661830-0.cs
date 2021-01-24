    protected override void OnDataBinding(EventArgs e)
    {
        TheTemplateContainer container = new TheTemplateContainer(this);
        if (TemplateName == "A")
            ATemplate.InstantiateIn(container);
        else if (TemplateName == "B")
            BTemplate.InstantiateIn(container);
        System.Web.UI.WebControls.PlaceHolder PlaceHolder1 = new System.Web.UI.WebControls.PlaceHolder();
        //PlaceHolder1.Controls.Clear();
        PlaceHolder1.Controls.Add(container);
        this.Controls.Clear();
        this.Controls.Add(PlaceHolder1);
        EnsureChildControls();
        base.OnDataBinding(e);
    }
