    var query = context.Users.Where(x => x.Id == id).Select(x => new
                    {
                        x.Id,
                        x.FirstName,
                        x.LastName,
                        x.UCP
                    })
                    .AsEnumerable()
                    .Select(x => new
                    {
                        x.Id,
                        x.FirstName,
                        x.LastName,
                        UCP = Decode(x.UCP)
                    });
                    response = Request.CreateResponse(HttpStatusCode.OK, query.ToList());
