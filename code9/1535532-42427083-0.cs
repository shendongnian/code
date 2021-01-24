    public async Task<IActionResult> Index()
	{
		var model = await _context
			.Metrics
			.Where(mt => mt.Type == Metrics.CpuLoad.AsInt())
			.ToListAsync();
		var result = View(model);
		result.StatusCode = (model.Any() ? HttpStatusCode.OK : HttpStatusCode.NoContent).AsInt();
		return result;
	}
