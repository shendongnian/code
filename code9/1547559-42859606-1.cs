	public class PhotoViewModel {
	   public SomeViewModel ParentViewModel { get; set; }
	   public PhotoModel Photo { get; set; }
	   public ICommand RemovePhotoCommand {
		  get {
			  return new MvxCommand(() => {
				  ParentViewModel.RemovePhotoCommand.Execute(this);
			  });
		  }
	   }
	}
