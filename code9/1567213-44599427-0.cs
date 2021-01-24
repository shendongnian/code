    using ComparedQueryable;
    
    public IHttpActionResult Get()
    {
        IEnumerable<Widget> widgets = this.service.GetWidgets();
        return widgets.AsNaturalQueryable();
    }
