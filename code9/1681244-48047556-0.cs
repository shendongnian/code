    EA.Package theModel;
    theModel = Repository.Models.GetAt( 0 );
    
    // Iterate through all views (top level packages) in the model
    foreach( EA.Package currentView in theModel.Packages )
    {
        // Add the name of this view to the output window
        MessageBox.Show( currentView.Name );
    }
