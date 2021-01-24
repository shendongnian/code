    Public Class Form1
        Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            FlowLayoutPanel1.Padding = New Padding(3, 3, 3, 3)
    
            Dim g As Graphics = Me.CreateGraphics()
            Dim size As SizeF
            ' check how much width needed for the string "Winforms"...'
            size = g.MeasureString("Winforms", Me.Font)
    
            Dim tagwinforms As New TagObject("Winforms", size.Width + TagObject.BtnRemoveWidth + 20, FlowLayoutPanel1.Height - 8)
            tagwinforms.Init()
            FlowLayoutPanel1.Controls.Add(tagwinforms)
    
            ' check how much width needed for the string "C#"...'
            size = g.MeasureString("C#", Me.Font)
    
            Dim tagcsharp As New TagObject("C#", size.Width + TagObject.BtnRemoveWidth + 20, FlowLayoutPanel1.Height - 8)
            tagcsharp.Init()
            FlowLayoutPanel1.Controls.Add(tagcsharp)
    
            g.Dispose()
        End Sub
    
    End Class
    
    Public Class TagObject
        Inherits Label
        Public Shared Property BtnRemoveWidth As Int16 = 20
        Public Shared Property BtnRemoveHeight As Int16 = 20
        ' note: you can add get set methods and in the set method you can change value in runtime '
        Public Property DescriptionText As String
        Private Property TagHeight As Int16
        Private Property TagWidth As Int16
        Private btnRemove As PictureBox
    
        ' you can add any property you need backcolor forecolor etc...'
        Sub New(ByVal descriptionText As String, ByVal width As Int16, ByVal height As Integer)
            Me.DescriptionText = descriptionText
            Me.TagHeight = height
            Me.TagWidth = width
            Me.Font = New Font("ARIAL", 8, FontStyle.Bold)
        End Sub
    
        Public Sub Init()
            Me.Text = DescriptionText
            Me.Width = TagWidth
            Me.Height = TagHeight
            Me.TextAlign = ContentAlignment.MiddleCenter
            Me.BackColor = Color.FromArgb(30, 30, 30)
            Me.ForeColor = Color.White
            btnRemove = New PictureBox()
            btnRemove.Height = BtnRemoveHeight
            btnRemove.Width = BtnRemoveWidth
            btnRemove.Location = New Point(TagWidth - btnRemove.Width - 1, TagHeight / 2 - btnRemove.Height / 2)
            ' original image url: https://www.google.co.il/search?q=close+icon+free&safe=off&rlz=1C1ASUM_enIL700IL700&source=lnms&tbm=isch&sa=X&ved=0ahUKEwjVuJnbk5vZAhXKesAKHRXqDX8Q_AUICigB&biw=1440&bih=769#imgrc=2p_iHiqieStqCM:'
            btnRemove.Image = My.Resources.CloseIcon
            btnRemove.Cursor = Cursors.Hand
            AddHandler btnRemove.Click, AddressOf btnRemove_Click
            Me.Controls.Add(btnRemove)
        End Sub
    
        Private Sub btnRemove_Click(sender As Object, e As EventArgs)
            ' the user wants to delete this tag...'
            Me.Dispose()
        End Sub
    End Class
