    ViewBag.UserRoles = db.UserRoles.Select(
                                x => new SelectListItem
                                {
                                    Selected = true,
                                    Text = x.UserRoleName,
                                    Value = x.UserRoleID.ToString()
                                }
