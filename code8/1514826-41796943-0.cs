    for (int i = 0; i < rchtxbx_input.Text.Length; i++)
            {
                string answers = "";
                int InPutChar = Convert.ToInt32(rchtxbx_input.Text[i]);
                char c = '\u3400';
                // Implicit conversion: char is basically a 16-bit unsigned integer
                int LowestMagicChar = c;
                bool doCheck = true, multipleChar = false; //set true if statements will set false.
                if (InPutChar < LowestMagicChar) 
                {
                    rchtxbx_output.AppendText(rchtxbx_input.Text[i].ToString());
                    doCheck = false;
                }
                if (doCheck == true) //Could be MagicChar so more checks inside
                {
                    for (int j = 0; j < MagicString.Length; j++)
                    {
                        string[] InnerCharArray = MagicString[j];
                        for (int k = 1; k < InnerCharArray.Length; k++)
                        {
                            string unichar = InnerCharArray[k]; //Get next char to check
                            if (rchtxbx_input.Text[i].ToString() == unichar) //&& (doCheck))
                                                                             //check with the char in textbox
                            {
                                if (doCheck == true)
                                {
                                    answers = InnerCharArray[0]; //first time in we have one char
                                }
                                else
                                {
                                    answers += ";" + InnerCharArray[0]; //comes in here if multiple chars for same sound
                                    multipleChar = true;
                                }
                                // rchtxbx_output.AppendText(InnerCharArray[0] + " ");
                                //If the char then put down the sound and space.
                                doCheck = false;
