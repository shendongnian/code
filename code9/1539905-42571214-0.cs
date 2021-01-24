    using System.Diagnostics;    
    
    public FormThatWasCalled
    {
        StackTrace st = new StackTrace();
        string callingClassName = st.GetFrame(1).GetMethod().DeclaringType.Name;
        InitializeComponent();
    }
