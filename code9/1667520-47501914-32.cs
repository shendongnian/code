	public class Gallery : ObservableObject
	{
		private string _property1;
		public Gallery Property1
		{
			get { return _property1; }
			set
			{
				if (_property1 != value)
				{
					_property1 = value;
					NotifyPropertyChanged();
				}
			}
		}
		
		private Gallery _property2;
		public Gallery Property2
		{
			get { return _property2; }
			set
			{
				if (_property2 != value)
				{
					_property2 = value;
					NotifyPropertyChanged();
				}
			}
		}
		
		public Gallery() { }
	}
	public class AddGalleryViewModel : ObservableObject
	{
		private Gallery _galleryToAdd;
		public Gallery GalleryToAdd
		{
			get { return _galleryToAdd; }
			set
			{
				if (_galleryToAdd != value)
				{
					_galleryToAdd = value;
					NotifyPropertyChanged();
				}
			}
		}
		
		public ICommand AddGalleryCommand { get; set; }
		
		public AddGalleryViewModel()
		{
			AddGalleryCommand = new DelegateCommand(AddGallery, CanAddGallery)
            GalleryToAdd = new Gallery();
			GalleryToAdd.PropertyChanged += GalleryToAdd_PropertyChanged
		}
			
		private void AddGallery(object parameter)
		{
			Gallery gallery = (Gallery)parameter;
			...
		}
		
		private bool CanAddGallery(object parameter)
		{
			Gallery gallery = (Gallery)parameter;
			
			if (string.IsNullOrEmpty(gallery.Property1) || string.IsNullOrEmpty(gallery.Property2))
			{
				return false;
			}
			return true;
		}
		
		private void GalleryToAdd_PropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			if (e.PropertyName == "Property1" || e.PropertyName == "Property2")
			{
				AddGalleryCommand.RaiseCanExecuteChanged();
			}
		}
	}
