            var obj = new ProizvodjacViewModel();
            List<SelectListItem> VendorList = new List<SelectListItem>
            {
                 new SelectListItem() { Value = "Gibson", Text = "Gibson" },
                 new SelectListItem() { Value = "Hohner", Text = "Hohner" },
                 new SelectListItem() { Value = "Yamaha", Text = "Yamaha" }
            };
           obj.VendorList = VendorList;
           return view(obj);
