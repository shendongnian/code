    '''  JSON, Use NuGet to Install NewtonSoft.Json
    Imports Newtonsoft.Json
    Imports System.IO
    Public Class SomethingIWantToSave
    
        Public Shared Function Load(byval path As String) As SomethingIWantToSave
    
            Dim result As SomethingIWantToSave = Nothing
            Dim content As String = String.Empty
    
            If File.Exists(path) Then
                content = File.ReadAllText(path)
                result = JsonConvert.DeserializeObject(Of SomethingIWantToSave)(content)
            End If
    
            return result
    
        End Function
    
    
    
        Public Sub Save(byval path As String)
    
            Dim content As String = JsonConvert.Serialize(Me)
    
            File.WriteAllText(path, content)
    
        End Sub
    
    End Class
    
    
    Use the class like so:
        ' load existing data
        Dim data As SomethingIWantToSave = SomethingIWantToSave.Load(Path.Combine("c:\yadda", "yadda", "content.json"))
    
        ' make changes if you like.
        ...
    
        ' save data back to disk
        data.Save(Path.Combine("c:\yadda", "yadda", "content.json"))
