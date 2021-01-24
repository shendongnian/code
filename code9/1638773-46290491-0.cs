               var collection = new BlockingCollection<AnnotationRequest>();
               Task.Run(() =>
               {
                   Parallel.ForEach(requests, (request) =>
                  {
                      foreach (var result in Infer(request, token))
                      {
                          collection.Add(result);
                      }
                  });
                   collection.CompleteAdding();
               });
                foreach (var result in collection.GetConsumingEnumerable())
                {
                    yield return result;
                }
