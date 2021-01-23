            using System.Web.Mvc;
            public List<SelectListItem> DropdownListFilter()
            {
                var listitem = new List<SelectListItem>();
                listitem.Add(new SelectListItem { Text = "Dropdown1", Value = "0", Selected = true });
                listitem.Add(new SelectListItem { Text = "Dropdown2", Value = "1", Selected = false });
                listitem.Add(new SelectListItem { Text = "Dropdown3", Value = "2", Selected = false });
                return listitem;
            }
