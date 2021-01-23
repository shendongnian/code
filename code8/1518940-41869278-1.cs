    In controller  you can do like this  .I tested with console application.
        		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Create([Bind(Include = "MaterialId,Name,")] Material material)
		{
			if (ModelState.IsValid)
			{
			 using (var ctx = new SampleDbContext())
			{
                -- here context is the DBCOntext class of your application 
				--var mat = new Material
				--{
				--    Name = "A",
				--    Project = new List<Project> {new Project {Name = "P1", Date = DateTime.Now}}
				--};
				ctx.Materials.Add(material);           
				await db.SaveChangesAsync();
			}
           
				return RedirectToAction("Index");
			}
			return View(material);
		}
