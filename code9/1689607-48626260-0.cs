        Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Controls.Add(New TestTextBox With {.Text = "The quick brown fox j___ed over the l__y hound", .Dock = DockStyle.Fill, .Multiline = True})
    End Sub
    Public Class TestTextBox
        Inherits Windows.Forms.TextBox
        Protected Overrides Sub OnKeyDown(e As KeyEventArgs)
            Dim S = Me.SelectionStart
            Me.SelectionStart = ReplceOnlyWhatNeeded(Me.SelectionStart, (Chr(e.KeyCode)))
            e.SuppressKeyPress = True ' Block Evrything 
        End Sub
        Public Overrides Property Text As String
            Get
                Return MyBase.Text
            End Get
            Set(value As String)
                'List Of Editable Symbols 
                ValidIndex.Clear()
                For x = 0 To value.Length - 1
                    If value(x) = DefaultMarker Then ValidIndex.Add(x)
                Next
                MyBase.Text = value
                Me.SelectionStart = Me.ValidIndex.First
            End Set
        End Property
        '---------------------------------------
        Private DefaultMarker As Char = "_"
        Private ValidIndex As New List(Of Integer)
        Private Function ReplceOnlyWhatNeeded(oPoz As Integer, oInputChar As Char) As Integer
            'Replece one symbol in string at pozition, in case delete put default marker
            If Me.ValidIndex.Contains(Me.SelectionStart) And (Char.IsLetter(oInputChar) Or Char.IsNumber(oInputChar)) Then
                MyBase.Text = MyBase.Text.Insert(Me.SelectionStart, oInputChar).Remove(Me.SelectionStart + 1, 1) ' Replece in Output String new symbol
            ElseIf Me.ValidIndex.Contains(Me.SelectionStart) And Asc(oInputChar) = 8 Then
                MyBase.Text = MyBase.Text.Insert(Me.SelectionStart, DefaultMarker).Remove(Me.SelectionStart + 1, 1) ' Add Blank Symbol when backspace
            Else
                Return Me.ValidIndex.First  'Avrything else not allow
            End If
            'Return Next Point to edit 
            Dim Newpoz As Integer? = Nothing
            For Each x In Me.ValidIndex
                If x > oPoz Then
                    Return x
                    Exit For
                End If
            Next
            Return Me.ValidIndex.First
        End Function
    End Class
