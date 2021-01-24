    Public Shared Function mergeObjectInTemplatedata(template As Object, 
                                                     source As Object, 
                                                     Optional parents As List(Of String) = Nothing) As Object
        If parents Is Nothing Then
            parents = New List(Of String)
        End If
        For Each prop As PropertyInfo In template.GetType().GetProperties()
            Dim value As Type = prop.GetValue(template).GetType()
            If value = GetType(String) Or value = GetType(Integer) Then
                prop.SetValue(template, getFromSource(source, parents, prop.Name))
            Else
                parents.Add(prop.Name)
                mergeObjectInTemplatedata(prop.GetValue(template), source, parents)
            End If
        Next
        Return template
    End Function
    Private Shared Function getFromSource(source As Object, 
                                          location As List(Of String), 
                                          propertyName As String) As Object
        Dim obj As Object = source
        For Each item As String In location
            obj = CallByName(obj, item, CallType.Get)
        Next
        Return CallByName(obj, propertyName, CallType.Get)
    End Function
