    // 'gc' is of type yWorks.yFiles.UI.GraphControl.  
     
    var ihim = new ItemHoverInputMode(); 
    ihim.HoveredItemChanged += YourEvenHandler;
    gc.InputModes.Add(ihim);
