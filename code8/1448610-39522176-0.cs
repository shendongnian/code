    Public Class Form1
        Private WithEvents p As New System.Diagnostics.Process
        Public Event pEnd As EventHandler
        Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            p.StartInfo.FileName = "notepad.exe"
            p.EnableRaisingEvents = True
            p.Start()
        End Sub
        Private Sub p_Ended(ByVal sender As Object, ByVal e As System.EventArgs) Handles p.Exited
            DoYourPostExitFileProcessing()
        End Sub
    End Class
