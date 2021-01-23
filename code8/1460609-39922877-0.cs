    if (matchedEngineer != null)
        {
            ViewBag.EngineerId = new SelectList(new List<Engineer> { matchedEngineer }, "PersonId", "FullName");
            // new up list below
            ViewBag.ManagerId = new SelectList(new List<Manager>, "PersonId", "FullName");
        }
