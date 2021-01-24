            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Create(SupportProcessViewModel vm)
            {
                if (ModelState.IsValid)
                {
                    if (vm.SelectedStartProcess > 0)
                    {
                        vm.SupportProcess.StartProcess = db.SupportProcesses.Find(vm.SelectedStartProcess);
                    }
                    db.SupportProcess.Attach(vm.SupportProcess);
                    db.SupportProcesses.Add(vm.SupportProcess);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(vm);
            }
