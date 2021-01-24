    using System.Linq;
    
    ...
    
    foreach (var control in Controls.Where(c => c is TextBox))
    {
        // ...
    }
