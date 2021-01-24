    Public MustInherit Class Test
        Inherits UserControl
        Public Shared ReadOnly TestTitleProperty As DependencyProperty = DependencyProperty.Register("TestTitle", GetType(String), GetType(Test), New UIPropertyMetadata(String.Empty, AddressOf TestChanged))
        Public Property TestTitle As String
            Get
                Return CType(GetValue(TestTitleProperty), String)
            End Get
            Set
                SetValue(TestTitleProperty, Value)
            End Set
        End Property
        Private Shared Sub TestChanged(d As DependencyObject, e As DependencyPropertyChangedEventArgs)
            '...
        End Sub
        Public MustOverride Sub DoThing()
    End Class
