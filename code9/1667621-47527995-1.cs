	[HttpPost]
	[ValidateAntiForgeryToken]
	public ActionResult Insert(employee emp, string langs)
	{
		if (ModelState.IsValid)
		{
			using(DbContext db = new DbContext())
			{	
				if(langs != null)
				{
					string[] strLangs = langs.Split('-');
					foreach (var l in strLangs)
					{
						string lan = l.Trim();
						while (lan.Contains("  "))
							lan.Replace("  ", " ");
						emp.language.Add(new language
						{
							languageName = lan
						});
					}
				}
				db.employee.Add(emp);
				db.SaveChanges();
				return View("YourReturnPage");
			}
        }
        return View(Insert);
	}
