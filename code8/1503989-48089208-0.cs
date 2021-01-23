              //About the null issue. You can use this.
              if(String.IsNullOrEmpty(txtusername.Text))
                {
                    throw new Exception("Cannot be blank!");
                }
            //You can filter the entry before saving it into the database
            txtpageid.Text = book.PageID.Trim();
            txtfoldername.Text = book.FolderName.Trim();
