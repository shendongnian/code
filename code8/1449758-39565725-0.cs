    Widget {
        public string Name {g;s;}
        ... //more fields
        public virtual ICollection<WidgetOption> WidgetOptions {g;s;}
    }
    
    WidgetOption {
        public string Option {g;s;}
        ... //more fields
        public virtual ICollection<Widget> Widgets {g;s;}
    }
