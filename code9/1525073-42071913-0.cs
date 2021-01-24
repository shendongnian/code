    private void button1_Click(object sender, EventArgs e)
            {
                ColorForTwoSeconds((Button)sender);
            }
    
            private void ColorForTwoSeconds(Button button)
            {
                var originalColor = button.BackColor;
                button.BackColor = Color.Red;
    
                Task.Run(() => ResetBackColor(originalColor));
            }
    
            void ResetBackColor(Color originalColor)
            {
                Thread.Sleep(2000);
                this.button1.BeginInvoke((MethodInvoker) delegate
                {
    
                    this.button1.BackColor = originalColor ;
                });   
            }
