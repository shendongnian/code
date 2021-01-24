    //##!!Don't do this!!
            var thread = new Thread(() =>
            {
                int x = 10;
                int y = 100;
                int howeverManyThreadsIWant = numberOfTimesToHash;
                for (int i = 0; i < howeverManyThreadsIWant; i++) 
                {
                    TextBox textBox = new TextBox();
                    textBox.Tag = i;
                    textBox.Location = new Point(x, y);
                    
                    //Could go into a recursive function such as MD5(Input,recursionDepth)
                    //But instead going to simply reprint same hash
                    textBox.Text = MD5(txtboxHashInput.Text);
                    //MessageBox.Show(textBox.Text);
                    this.Controls.Add(textBox);//<--invalid operations error
                    y += 30;
                }
                
            });
            thread.Start();
