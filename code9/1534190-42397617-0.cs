    Public Class TextBoxUC
        Public Property Text() As String
            Get
                Return CType(Me.GetValue(TextProperty), Boolean)
            End Get
            Set(ByVal value As String)
                Me.SetValue(TextProperty, value)
            End Set
        End Property
        Public Shared ReadOnly TextProperty As DependencyProperty = DependencyProperty.Register("Text", GetType(String), GetType(TextBoxUC), New PropertyMetadata(Nothing))
    End Class
