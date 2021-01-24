    using System.Linq;
    
    ...
    
    foreach (var control in Controls.Cast<Control>().Where(c => c is TextBox))
    {
        // ...
    }
