    static readonly Image DefaultImage = Properties.Resources.DefaultImage;
    static readonly Image EmptyPhone = Property.Resources.EmptyPhoto;  
    private void saveBtn_Click(object sender, EventArgs e)
            {
                imgBox.Image.Dispose();
                imgBox.Image = DefaultImage;
                if (imgBox.Image == DefaultImage)
                {
                    MessageBox.Show("Warning! Cannot save this image!");
                }
                else
                {
                    SaveNoti save = new SaveNoti();
                    save.sender = new SaveNoti.SEND(Task_functions);
                    save.ShowDialog();
                }
