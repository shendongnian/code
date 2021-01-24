    data.Node.Add(new Node {
                      viewer = setup.Device[moduleNr].viewer,
                      viewerId = setup.Device[moduleNr].viewerId ,
                      log = setup.Device[moduleNr].log,
                      Link = new List<Link>
                      {
                          new Link
                          {
                              keyName = "Link 1",
                              value = 0
                          },
                          new Link
                          {
                              keyName = "Link 2",
                              value = 1
                          }
                      }     
                  });
