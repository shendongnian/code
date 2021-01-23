        if (checkBox1.Checked)
                {
                    ReconEngine_Programmer.RecognizeAsync(RecognizeMode.Multiple);
        
                }
                else
                {
                    //not checked
                }
        
                if (checkBox2.Checked)
                {
                    ReconEngine_Data_Specialist.RecognizeAsync(RecognizeMode.Multiple);
        
                }
                else
                {
                    //not checked
                }
