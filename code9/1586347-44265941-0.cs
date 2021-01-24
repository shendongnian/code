    private BitmapImage _Image = null;
		/// <summary>
		/// the image 
		/// </summary>
		public BitmapImage Image
		{
			get
			{
				if (_Image == null)
					_Image = (DocumentFactory.Instance.GetService(Parent) as BookService).GetImageFromStream(Parent.FilePath, FilePath);
				ImageLastAcces = DateTime.Now;
				return _Image;
			}
			set { _Image = value; }
		}
