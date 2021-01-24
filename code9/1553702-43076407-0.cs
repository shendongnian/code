    public enum UserPermissions{
        FilesRead,
        FilesWrite,
        FoldersRead,
        FoldersWrite,
        NotesCreate,
        NotesDelete,
        NotesModify,
    }
    public class UserPermissions
    {
        public enum Files
        {
            Read  = UserPermissions.FilesRead,
            Write = UserPermissions.FilesWrite,
        }
    
        public enum Folders
        {
            Read  = UserPermissions.FoldersRead,
            Write = UserPermissions.FoldersWrite,
        }
    }
