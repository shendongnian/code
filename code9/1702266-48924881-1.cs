    public async Task<IActionResult> Index(int? primary_id)
        {
			ProductIdentifier pi = await _context.ProductIdentifiers
									.Where(i => i.Id == primary_id)
									.SingleOrDefaultAsync();
			ViewModelEditIdentifierInIndexView ViewModel = new ViewModelEditIdentifierInIndexView
			{
				SingleItem = _mapper.Map<ViewModelProductIdentifier>(pi),
				ListOfItems = _mapper.Map<ICollection<ViewModelProductIdentifier>>(await _context.ProductIdentifiers.ToListAsync())
			};
			return View(ViewModel);
        }
