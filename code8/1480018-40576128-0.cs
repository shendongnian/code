    switch (newButton.fileExtension)
            {
                case ".txt":
                    newButton.Image = System.Drawing.Image.FromFile(@"Some Directory\Project Code\Project images\Text document.png");
                    break;
                case ".png":
                case ".jpg":
                case ".gif":
                    newButton.Image = System.Drawing.Image.FromFile(@"Some Directory\Project images\Picture document.png");
                    break;
                case ".doc":
                    newButton.Image = System.Drawing.Image.FromFile(@"Some Directory\Project Code\Project images\Word Document.png");
                    break;
                default:
                    newButton.Image = System.Drawing.Image.FromFile(@"Some Directory\Project Code\Project images\Unknown Document.png");
                    break;
            }
