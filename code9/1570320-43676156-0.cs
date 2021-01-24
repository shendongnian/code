    Task.Factory.StartNew(() =>
                                  {                           
                                      
                                          Thread.Sleep(5000);
                                          foreach (truck in detectedTruck )
                                          {
                                              truck.PropertyToChange = true;
                                          }
                                      
                                  });
