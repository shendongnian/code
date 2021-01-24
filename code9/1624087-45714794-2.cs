    Enumerable.Range(0, nVars)
              .SelectMany(i => {
                                   return new[]
                                          {
                                              new NonlinearConstraint(nVars, x => x[i] >= 0),
                                              new NonlinearConstraint(nVars, x => x[i] <= 1),
                                          };
                               })
              .ToArray();
