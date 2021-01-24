        public class InventoryController : Controller
        public ActionResult WebgridSample()
        {
            ObservableCollection<Product> inventoryList =
                new ObservableCollection<Product>();
            inventoryList.Add(new Product
            {
                Id = "P101",
                Name = "Computer",
                Description = "All type of computers",
                quantity = new List<Quantity>
                {
                    new Quantity {QUAN = 100 },
                    new Quantity {QUAN = 200 },
                    new Quantity {QUAN = 300 }
                }
            });
            inventoryList.Add(new Product
            {
                Id = "P102",
                Name = "Laptop",
                Description = "All models of Laptops",
 
                quantity = new List<Quantity>
                {
                    new Quantity {QUAN = 400 },
                    new Quantity {QUAN = 500 },
                    new Quantity {QUAN = 600 }
                },
            });
            inventoryList.Add(new Product
            {
                Id = "P103",
                Name = "Camera",
                Description = "Hd  cameras",
                quantity = new List<Quantity>
                {
                    new Quantity {QUAN = 700 },
                    new Quantity {QUAN = 800 },
                    new Quantity {QUAN = 900 }
                }
            });
            IEnumerable<string> model = (from sig in inventoryList
                                        select new ViewModel
                         {
                             Name = sig.Name,
                             Description = sig.Description,
                             quan = sig.quantity.FirstOrDefault(),
                         }).ToList();
            return View(model);
        }
 
