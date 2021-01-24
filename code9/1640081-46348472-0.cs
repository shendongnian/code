    Public Class MyContext 
        Inherits DbContext
        Public Property Users As DbSet(of User)
        Public Property Folders As DbSet(of Folder)
    End Class
