    using System.Linq;
    
    ...
    
    foreach (Control c in Controls.Where(c => c is TextBox))
    {
        // ...
    }
