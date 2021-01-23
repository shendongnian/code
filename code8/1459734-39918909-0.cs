    Public Class GenericEventArgs(Of TEventData)
      Inherits EventArgs
      Public Sub New(Optional eventData As TEventData = Nothing)
        Me.EventData = eventData
      End Sub
      Public Property EventData As TEventData
    End Class
    
    Class MainWindow
      Private Sub Me_DataContextChanged(sender As Object, e As DependencyPropertyChangedEventArgs) Handles Me.DataContextChanged
          Dim mainWindowVM = DirectCast(DataContext, MainWindowViewModel)
          AddHandler mainWindowVM.SavingChanges, AddressOf MainWindowViewModel_SavingChanges
      End Sub
      Private Sub MainWindowViewModel_SavingChanges(sender As Object, e As GenericEventArgs(Of Boolean?))
        If MessageBox.Show("Save changes?",
                           "Document was changed",
                           MessageBoxButton.YesNo,
                           MessageBoxImage.Exclamation) = MessageBoxResult.Yes Then
          e.EventData = True
        Else
          e.EventData = False
        End If
      End Sub
    End Class
    
    Class MainWindowViewModel
      Public Event SavingChanges As EventHandler(Of GenericEventArgs(Of Boolean?))
      Public Sub SaveChanges()
        Dim e As New GenericEventArgs(Of Boolean?)
        RaiseEvent SavingChanges(Me, e)
        If e.EventData = True Then
          'User want to save changes
        Else
          'User dont want to save changes
        End If
      End Sub
    End Class
