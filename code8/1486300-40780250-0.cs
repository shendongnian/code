    ViewBag.Teamnames = _db.Team.Select(c => new SelectListItem
                    {
                        Text = c.Teamname ,
                        Value = c.MainEntryId.ToString(),
                        Selected = true
                    });
