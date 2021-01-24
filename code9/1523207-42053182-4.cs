            public async Task<ActionResult> ShowReviewDetails(string searchProduct, int? page, string perPage)
        {
            // get product via id
            var prodId = Convert.ToInt32(searchProduct);
            if (prodId > 0)
            {
                var dbProd = await _context.Product.FindAsync(prodId);
                var prod = new Product()
                {
                    Id = dbProd.Id,
                    ProductName = dbProd.ProductName,
                    Cost = dbProd.Cost,
                    ProductCategory = dbProd.ProductCategory,
                    ProductDescription = dbProd.ProductDescription,
                };
                searchProduct = prod.ProductName;
            }
            else
            {
                searchProduct = "All";
            }           
            if (perPage == "0")
            {
                perPage = _context.Product.Count().ToString();
            }
            var perPageGet = Convert.ToInt32(perPage);
            if (perPageGet <= 0)
            {
                perPageGet = _context.Product.Count();
            }
            int pageSize = Convert.ToInt32(perPageGet);
            int pageNumber = (page ?? 1);
            IEnumerable<Review> reviews = await _context.Review.Where(r => r.ReviewApproved == true).ToListAsync();
            if (!string.IsNullOrWhiteSpace(searchProduct) || !string.IsNullOrEmpty(searchProduct))
            {
                
                searchProduct = StringExtensions.UppercaseFirst(searchProduct);
            }           
            if (!string.IsNullOrEmpty(searchProduct) || !string.IsNullOrWhiteSpace(searchProduct) || searchProduct == "0")
            {
                page = 1;
                reviews = await _context.Review.Where(r => r.Product == searchProduct && r.ReviewApproved == true).ToListAsync();
            }
            if (searchProduct == "All" || string.IsNullOrEmpty(searchProduct))
            {
                reviews = await _context.Review.Where(r => r.ReviewApproved == true).ToListAsync();
            }
            reviews = reviews.ToPagedList(pageSize, pageNumber);
            return PartialView(reviews);
        }
