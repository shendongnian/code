    public enum UserPermissions{
        FilesRead,
        FilesWrite,
        FoldersRead,
        FoldersWrite,
        NotesCreate,
        NotesDelete,
        NotesModify,
    }
    public class UserPermission //Other name then enum, or the class must be under a different namespace
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
