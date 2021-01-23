    @{
           List<SelectListItem> listItems= new List<SelectListItem>();
           listItems.Add(new SelectListItem
                {
                  Text = "Exemplo1",
                  Value = "Exemplo1"
                });
           listItems.Add(new SelectListItem
                {
                    Text = "Exemplo2",
                    Value = "Exemplo2",
                    Selected = true
                });
           listItems.Add(new SelectListItem
                {
                    Text = "Exemplo3",
                    Value = "Exemplo3"
                });
        }
        
        @Html.DropDownListFor(model => model.order, listItems, "-- Select Order--")
