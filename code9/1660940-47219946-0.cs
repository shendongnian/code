    Sub Foo()
        Dim targetClass As BaseClass = BaseClass.CreateDerived()
        Dim Casted As Interf
        If TypeOf (targetClass) Is DerivedClass1 Then
            Casted = DirectCast(targetClass, DerivedClass1)
        ElseIf TypeOf (targetClass) Is DerivedClass2 Then
            Casted = DirectCast(targetClass, DerivedClass2)
        Else
            Exit Sub
        End If
        Console.WriteLine(Casted.MyProperty) 'Throws an exception.
    End Sub
    Friend Interface Interf
        Property MyProperty As Integer
    End Interface
    Public Class BaseClass
        Implements Interf
        Private Shared Rand As New Random
        Friend Overridable Property MyProperty As Integer Implements Interf.MyProperty
        Public Shared Function CreateDerived() As BaseClass
            Return If(Rand.Next(1, 3) = 1, New DerivedClass1(), New DerivedClass2())
        End Function
    End Class
    Public Class DerivedClass1
        Inherits BaseClass
        Sub New()
            MyProperty = 1
        End Sub
        Friend Overrides Property MyProperty As Integer
    End Class
    Public Class DerivedClass2
        Inherits BaseClass
        Sub New()
            MyProperty = 2
        End Sub
        Friend Overrides Property MyProperty As Integer
    End Class
