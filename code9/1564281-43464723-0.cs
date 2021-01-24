    var enumlist = Enum.GetValues(typeof(DeliveryPermitStatus)).Cast<DeliveryPermitStatus>().Select(v => new SelectListItem
                {
                    Text = v.ToString(),
                    Value = ((int)v).ToString()
                });
                if (User.IsInRole(StaticRoleNames.Admin)) //your condition here
                {
                    ViewBag.enumlist = enumlist.Where(t =>  t.Text == "Arrived" || t.Text == "Completed");
                }
