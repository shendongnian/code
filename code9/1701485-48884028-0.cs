    Public Class Window1
    Public Confirmed as boolean = false
    'I have set to default as boolean as the user could theroretically close the
    'form and not click on either button!?
    Private Sub Button2_Click(sender As System.Object, e As System.Windows.RoutedEventArgs) Handles Button2.Click
        Confirmed = true
        ''System.Windows.Application.Current.Shutdown()
        me.close
    End Sub
    
    Private Sub Button1_Click(sender As System.Object, e As System.Windows.RoutedEventArgs) Handles Button1.Click
        Confirmed = false
        Me.Close()
    End Sub
    
    End Class
    Class MainWindow
    
    Private Sub MainWindow_Closing(sender As System.Object, e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Dim myWindow As New Window1()
        ''myWindow.Owner = Application.Current.MainWindow ''I dont know why you need this?
        myWindow.Inline1.Text = "Do you really want to quit?"
        myWindow.ShowDialog()
        if mywindow.confirmed then
             System.Windows.Application.Current.Shutdown()
             ''or simply..
             ''application.exit()
        else
             e.Cancel = True
        end if
    End Sub
    
    End Class
