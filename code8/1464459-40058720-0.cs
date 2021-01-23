    var query = _context.ResourceGroup
                        .SelectMany
                         (
                              rg => rg.ServersGroup
                                      .Select(sg => new 
                                      {
                                          ResourceGroup = rg.Name,
                                          Application = rg.Application.Name,
                                          Server = sg.Server.ServerName,
                                          // etc.
                                      })
                         )
