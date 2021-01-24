    class Container
    {
        public bool IsConfirmationNeeded { get; }
        public IEnumerable<IItem> MyData { get; } // any data you need to pass
    }
    FrmAccounts frm = new FrmAccounts();
    frm.Tag = new Container();
    
    var container = (Container)frm.Tag;
    var confirmation = container.IsConfirmationNeeded; // false by default
