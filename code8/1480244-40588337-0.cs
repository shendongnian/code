	    public virtual ActionResult FileDisplay(string fileName, int fileId, bool isFile)
	    {
	        var viewModel = new IFrameDocumentDisplayViewModel
	        {
	            FileName = fileName,
	            FileId = fileId,
	            IsFile = isFile
	        };
            return PartialView("IFrameFileDisplayView", viewModel);
        }
        public virtual ActionResult GetFile(int fileId, bool isFile)
		{
			var viewmodel = _presenter.GetDocumentDisplayViewModel(fileId, isFile);
            return base.File(viewmodel.Data, viewmodel.MediaType);
		}
