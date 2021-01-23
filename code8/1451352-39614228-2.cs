	[HttpPost]
	[ValidateAntiForgeryToken]
	public ActionResult Details(PostViewModel viewModel)
	{
		Comment comment = new Comment
		{
			CommnetMessage = viewModel.CommentMessage,
			// and other properties
		}
		
		// Save your model and etc.
	}
