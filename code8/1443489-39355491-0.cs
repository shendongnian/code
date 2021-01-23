    Imports System.Runtime.CompilerServices
    Imports System.ComponentModel
    Public Module EnumerationExtensions
    ''This procedure gets the <Description> attribute of an enum constant, if any.
    ''Otherwise, it gets the string name of then enum member.
    <Extension()> _
    Public Function Description(ByVal EnumConstant As [Enum]) As String
        Dim fi As Reflection.FieldInfo = EnumConstant.GetType().GetField(EnumConstant.ToString())
        Dim attr() As DescriptionAttribute = DirectCast(fi.GetCustomAttributes(GetType(DescriptionAttribute), False), DescriptionAttribute())
        If attr.Length > 0 Then
            Return attr(0).Description
        Else
            Return EnumConstant.ToString()
        End If
    End Function
    End Module
