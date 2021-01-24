    public static T Create<T>(IDocumentLibraryCreator<T> repo)// You can add you params here 
                where T:  DocumentLibrary, new()
            {
                var newItem = new T();
    
                repo.Create(newItem);
    //Do your stuff here
                return newItem;
            }
    
    
            public interface IDocumentLibraryCreator<T> where T : DocumentLibrary
            {
                Task Create(T document);
            } 
    
            public abstract class DocumentLibrary
            {
    
            }
