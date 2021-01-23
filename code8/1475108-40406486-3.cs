    var r= await Task.WhenAll(seeds.Select(async seed =>new {
                                                              Seed= seed,
                                                              Result = await Calculation(seed) 
                                                            }
                                          )
                             );  
