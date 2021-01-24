    async Task Do()
    {
    	var libraryMapper = new Func<LibraryView, Library>(lv => /*implement me*/ new Library());
    	var folderMapper = new Func<FolderView, Folder>(fv => /*implement me*/ new Folder());
    
    	var librariesSource = new Func<IObservable<LibraryView>>(() => /*implement me*/ Observable.Empty<LibraryView>());
    	var libraryFolderSource = new Func<LibraryView, IObservable<FolderView>>(lv => /*implement me*/ Observable.Empty<FolderView>());
    
    }
    
    public class Library 
    {
    	public List<Folder> Folders { get; set; }
    }
    public class Folder { }
    public class LibraryView { }
    public class FolderView { }
