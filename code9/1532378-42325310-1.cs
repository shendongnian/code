    Imports System
    Imports System.Collections.Generic
    Imports System.Windows.Forms
    Namespace FormStack
	    Partial Public Class StackingControl
		    Inherits UserControl
		    Private TopText As New Label()
		    Private OurFormStack As New Stack(Of Form)()
		    Public Sub New()
			    InitializeComponent()
			    TopText.Text = "The stack is empty"
			    Controls.Add(TopText)
		    End Sub
		    Public Sub AddForm(ByVal f As Form)
			    If OurFormStack Is Nothing Then
				    Throw New ApplicationException("FormStack is null")
			    End If
			    Controls.Clear()
			    OurFormStack.Push(f)
			    f.FormBorderStyle = FormBorderStyle.None
			    f.TopLevel = False
			    f.ShowInTaskbar = False
			    f.Visible = True
			    f.Dock = DockStyle.Fill
			    Controls.Add(f)
		    End Sub
		    Public Sub RemoveForm(ByVal f As Form)
			    If OurFormStack Is Nothing Then
				    Throw New ApplicationException("FormStack is null")
			    End If
			    If OurFormStack.Count = 0 Then
				    Throw New ApplicationException("FormStack is empty")
			    End If
			    Controls.Clear()
			    If OurFormStack.Pop() IsNot f Then
				    Throw New ApplicationException("The current form is not being removed")
			    End If
			    If OurFormStack.Count = 0 Then
				    Controls.Add(TopText)
				    Return
			    End If
			    Controls.Add(OurFormStack.Peek())
		    End Sub
	    End Class
    End Namespace
