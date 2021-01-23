      Public Shared ReadOnly OuterGraphicProperty As DependencyProperty =
        DependencyProperty.Register("OuterGraphic", GetType(ImageSource), GetType(CardBox), New PropertyMetadata(Nothing))
    
      Public Property OuterGraphic As ImageSource
        Get
          Return CType(GetValue(OuterGraphicProperty), ImageSource)
        End Get
        Set(value As ImageSource)
          SetValue(OuterGraphicProperty, value)
        End Set
      End Property
