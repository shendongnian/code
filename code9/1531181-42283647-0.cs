            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<ActionResult> Edit(PersonViewModel pvm)
            {
                if (ModelState.IsValid)
                {
                    List<IdentityRole> roles = adb.Roles.ToList();
                    var person = db.people.Where(x => x.PersonId == pvm.PersonId).FirstOrDefault();
                    var usr = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
                    foreach (var x in roles)
                    {
                        await usr.RemoveFromRoleAsync(person.NetId, x.Name);
                    }
                    await usr.AddToRoleAsync(person.NetId, pvm.SetRole);
                    person.CurrentRole = pvm.SetRole;
                    db.SaveChanges();
                    adb.SaveChanges();
                }
                return RedirectToAction("Index");
            }
