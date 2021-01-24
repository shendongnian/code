    var pinnedPages = context.Pages
                             .Select(p => new
                                          {
                                              Page = p
                                              Pins = p.Pins.Count()
                                          });
    
    foreach (var pinnedPage in pinnedPages)
    {
        var numberOfTimesPinned = pinnedPage.Pins;
        var pin = pinnedPage.Page; 
    
        //write a line to the report
    }
