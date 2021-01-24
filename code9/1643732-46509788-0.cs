    // Create the interop host control.
            System.Windows.Forms.Integration.WindowsFormsHost host =
                new System.Windows.Forms.Integration.WindowsFormsHost();
            // Create the PictureBox control.
            PictureBox picBox = new PictureBox();
            picBox.Width = 350;
            picBox.Height = 300;
            // Assign the MaskedTextBox control as the host control's child.
            ima.Child = picBox;
            // Add the interop host control to the Grid
            // control's collection of child controls.
            this.grid1.Children.Add(host);
                        
