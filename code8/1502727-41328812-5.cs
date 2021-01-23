	public ActionResult Download(int NoteID)
	{
		var fs = db.Files.Where(f => f.NoteID == NoteID);
		var fileNames = Directory
			.EnumerateFiles(Server.MapPath("/Files"))
			.Select(f => Path.GetFileName(f));
		var result = new List<string>();
		foreach (var fileName in fs)
		{
			var filteredByName = fileNames.Where(f => f.StartsWith(fileName));
			result.AddRange(filteredByName);
		}
		ViewBag.Files = result.ToArray();
		return View(); 
	}
