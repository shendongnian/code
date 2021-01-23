    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        pngImage = Image.FromFile(FOLDER_PATH & "\completed.png") //load it once
        picBoxImage = CType(pngImage.Clone, Image)
        
        PictureBox1.Size = New Size(CInt(463 / 2), CInt(242 / 2))
        PictureBox1.Parent = GroupBox6
        PictureBox1.Image = picBoxImage
        PictureBox1.Visible = False //you dont want it at the beggining
    End Sub
