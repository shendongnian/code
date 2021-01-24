    Enumerable.Range(0, nVars)
              .SelectMany(i => {
                                   var localI = i;
                                   return new[]
                                          {
                                              new NonlinearConstraint(nVars, x => x[localI] >= 0),
                                              new NonlinearConstraint(nVars, x => x[localI] <= 1),
                                          };
                               })
              .ToArray();
