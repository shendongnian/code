    var enumlist = Enum.GetValues(typeof(DeliveryPermitStatus)).Cast<DeliveryPermitStatus>().Select(v => new SelectListItem
                {
                    Text = v.ToString(),
                    Value = ((int)v).ToString()
                });
                
                List<SelectListItem> availableOptions = new List<SelectListItem>();
                if (User.IsInRole(StaticRoleNames.Admin)) //your condition here
                {
                    foreach(var item in enumlist)
                    {
                        if(item.Text == "Arrived" || item.Text == "Completed")
                        {
                           availableOptions.Add(item);
                        }
                    }
                }
                ViewBag.enumlist = availableOptions;
