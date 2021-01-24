     [HttpPost]
        public ActionResult Index(FruitModel fruit)
        {
            fruit.Fruits = PopulateFruits();
            var selectedItem = fruit.Fruits.Find(p => p.Value == fruit.FruitId.ToString());
            if (selectedItem != null)
            {
                selectedItem.Selected = true;
                ViewBag.Message = "Fruit: " + selectedItem.Text;
                ViewBag.Message += "\\nQuantity: " + fruit.Quantity;
            }
     
            return View(fruit);
        }
