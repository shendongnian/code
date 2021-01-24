    private void batchRootFolderText_TextChanged(object sender, EventArgs e){
        if (!batchRootFolderText.Text.EndsWith("\\")){
            String temp = batchRootFolderText.Text;
            temp = temp.Substring(0, MyString.Length - 1);
            batchRootFolderText.Text = temp + "\\";
        }
    } 
