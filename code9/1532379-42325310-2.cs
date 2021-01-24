    Imports System
    Imports System.Windows.Forms
    Namespace FormStack
	    Partial Public Class Form1
		    Inherits Form
		    Public Sub New()
			    InitializeComponent()
		    End Sub
		    Private Sub formTwoToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles formTwoToolStripMenuItem.Click
			    Dim f As New Form2()
			    AddHandler f.FormClosed, AddressOf Subform_FormClosed
			    stackingControl2.AddForm(f)
		    End Sub
		    Private Sub formThreeToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles formThreeToolStripMenuItem.Click
			    Dim f As New Form3()
			    AddHandler f.FormClosed, AddressOf Subform_FormClosed
			    stackingControl2.AddForm(f)
		    End Sub
		    Private Sub Subform_FormClosed(ByVal sender As Object, ByVal e As FormClosedEventArgs)
			    Dim c As Form = TryCast(sender, Form)
			    If c Is Nothing Then
				    MessageBox.Show("sender is not a Form")
				    Return
			    End If
			    Try
				    stackingControl2.RemoveForm(c)
			    Catch ex As Exception
				    MessageBox.Show(ex.Message)
			    End Try
		    End Sub
		    Private Sub exitToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles exitToolStripMenuItem.Click
			    Close()
		    End Sub
	    End Class
    End Namespace
