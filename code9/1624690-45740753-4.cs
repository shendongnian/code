    Public Property SomethingWhichIsReadOnly As String
      Get
          Return something 
      End Get
      Private Set(ByVal value As String)
          something = value 'Setting the value to the Private Field
      End Set
    End Property
