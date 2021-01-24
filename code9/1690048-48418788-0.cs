    public class Folder
	{
		//Model PROPERTIES
		IEnumerable<File> Files { get; set; }
	}
	public class File
	{
		//Model PROPERTIES
	}
	public class FolderViewModel : INotifyPropertyChanged
	{
		//View Model PROPERTIES
		IEnumerable<FileViewModel> Files { get; set; }
	}
	public class FileViewModel : INotifyPropertyChanged
	{
		//View Model PROPERTIES
		public bool IsSelected { get; set; }
	}
