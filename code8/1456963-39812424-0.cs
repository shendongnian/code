    private void ModalForm_Shown(object sender, EventArgs e){
                if (!maskedTextBox1.MaskCompleted) // if there is missing parts it will return false, every false means prompts need in control
                {
                    string tempText = maskedTextBox1.MaskedTextProvider.ToDisplayString(); // get the last value with prompts
                    maskedTextBox1.Text = "";
                    maskedTextBox1.Text = tempText; // then set the last value.
                }
            }
