     bool isPressed_Num7 = false;
    bool isPressed_Num9 = false;
    private void Form1_KeyDown(object sender, KeyEventArgs e)
    {
        if ((e.KeyData == Keys.NumPad7) && (!isPressed_Num7))
        {
            isPressed_Num7 = true;
            Console.WriteLine("Keydown 7");
        }
        if ((e.KeyData == Keys.NumPad9) && (!isPressed_Num9))
        {
            isPressed_Num9 = true;
            Console.WriteLine("Keydown 9");
        }
    }
    private void Form1_KeyUp(object sender, KeyEventArgs e)
    {
        if ((e.KeyData == Keys.NumPad7)&&(isPressed_Num7==true))
        {
            isPressed_Num7 = false;
            Console.WriteLine("Keyup 7");
        }
        if ((e.KeyData == Keys.NumPad9)&&(isPressed_Num9==true))
        {
            isPressed_Num9 = false;
            Console.WriteLine("Keyup 9");
        }
    }
