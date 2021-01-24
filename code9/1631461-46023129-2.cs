    // takes any Control and return an emtpy string if Text is null or empty
    string GetTextOrEmpty(Control ctl)
    {
       var txt = ctl.Text; // base implementation of Text doesn't return null
       if (String.IsNullOrEmpty(txt)) {
         return String.Empty;
       } else {
         return txt;
       }
    }
