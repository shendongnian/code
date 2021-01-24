    [HttpPost]
    public ActionResult ItemListPartialView(string searchString)
         {
            var items = _itemControls.GetAllItems()
                .Select(x => new ItemOrderViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Price = Convert.ToString(x.Price, CultureInfo.InvariantCulture),
                    Size = x.Size + " " + x.QuantityType.Name,
                    Quantity = 0
                });
            if (!string.IsNullOrEmpty(searchString))
            {
                items = items.Where(x => x.Name.Contains(searchString)).ToList();
            }
            return PartialView("_ItemListPartialView", items);
        }
