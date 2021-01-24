    using System.Diagnostics;    
    
    public FormThatWasCalled
    {
        string caller = new StackTrace().GetFrame(1).GetMethod().DeclaringType.Name;
        InitializeComponent();
    }
