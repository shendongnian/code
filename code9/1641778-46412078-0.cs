    Imports System.Runtime.CompilerServices
    Public Module Extensions
        <Extension()> _
        Public Sub myMsgBox(ByVal TargetForm As Form, ByVal MsgText As String)
            formMsgbox.mainText = MsgText
            formMsgbox.Size = New Size(TargetForm.Width / 2, TargetForm.Height / 2)
            Dim Current_Screen As Screen = Screen.FromControl(TargetForm)
            ...the rest of your code...
        End Sub
    End Module
