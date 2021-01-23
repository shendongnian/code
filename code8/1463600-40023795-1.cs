       public static GUI CurrentGui {
         get {
           GUI gui = Application
            .OpenForms
            .OfType<GUI>()
            .LastOrDefault();
    
           // no such form found, you may want to create the form 
           if (null == gui) {
             gui = new GUI();
             gui.Show(); // <- let's show it up
           }
    
           return gui;
         }
       } 
       ...      
       public static void AddMediaToPanel(...) {
         ...
         CurrentGui.Add(MediaCanvas);
       }
