    var ListData = DATActx.Books.
                                  Where(B => B.DealContract != null).
                                  Select(B => new clsMonteCarlo.Leg()
                                  {
                                      BookID = B.ID,
                                      DealNo = B.DealNo,
                                      DealContract = B.DealContract,
                                      BookA = B.Option.Skews.BookA,
                                      Updated = B.Updated
                                  }).GroupBy(g=>g.DealContract).Select(gr=>gr.OrderByDescending(b=>b.Updated).First());
