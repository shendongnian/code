            var records = _context.Product
                .GroupJoin(_context.Ratings, p => p.Id, r => r.PID, (p, r) => new { Product = p, Ratings = r})
                .GroupJoin(_context.Comments, p => p.Product.Id, c => c.PID, (p, c) => new { p.Product, p.Ratings, Comments = c})
                .GroupJoin(_context.Views, p => p.Product.Id, v => v.PID, (p, v) => new { p.Product, p.Ratings, p.Comments, Views = v })
                .Select(p => new
                {
                    Id = p.Product.Id,
                    Name = p.Product.Name,
                    Comments = p.Comments,
                    Ratings = p.Ratings,
                    Views = p.Views
                })
                .ToList().Select(x => new Product
                {
                    Id = x.Id,
                    Name = x.Name,
                    Comments = x.Comments.ToList(),
                    Ratings = x.Ratings.ToList(),
                    Views = x.Views.ToList()
                }).ToList();
