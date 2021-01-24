            //YOUR TEXTBOX IS A REFERNCE HERE. SO THAT THE UPDATES ARE RETAINED
            void AddTo(ref TextBox tBox)
            {
                //VALIDATED YOUR TEXT BOX IF DATA EXISTS BEFORE UPDATING
                if (tBox.Text.Trim().Length > 0 )
                {
                    int num = 0;
                    //CHECK IF THE TEXT IS CONVERTIBLE TO NUMBER
                    if (int.TryParse(tBox.Text, out num))
                    {
                        num++;
                        tBox.Text = num.ToString();
                    }
                }
            }
