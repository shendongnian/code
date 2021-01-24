    bool lctrlKeyPressed;
    bool f1KeyPressed;
    void kbh_OnKeyPressed(object sender, Keys e)
    {
        if (e == Keys.LControlKey)
        {
            lctrlKeyPressed = true;
        }
        else if (e == Keys.F1)
        {
            f1KeyPressed= true;
        }
        CheckKeyCombo();
    }
    void kbh_OnKeyUnPressed(object sender, Keys e)
    {
        if (e == Keys.LControlKey)
        {
            lctrlKeyPressed = false;
        }
        else if (e == Keys.F1)
        {
            f1KeyPressed= false;
        }
    }
    void CheckKeyCombo()
    {
        if (lctrlKeyPressed && f1KeyPressed)
        {
            //Open Form
        }
    }
