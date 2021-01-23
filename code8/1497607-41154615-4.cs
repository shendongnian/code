    public static List<SelectListItem> GetItemTypes()
    {
            var itemTypes = new List<SelectListItem>
            {
                new SelectListItem{Text = "Select", Value = ""},
                new SelectListItem{Text = "Item1", Value = "Item1"},
                new SelectListItem{Text = "Item2", Value = "Item2"},
                new SelectListItem{Text = "Item3", Value = "Item3"}
            };
            return itemTypes;
     }
