    void DrawBodyParts(BodyParts bp)
    {
        Graphics g = pnl1.CreateGraphics();
        if (bp == BodyParts.head)
        {
            pbHead.Show();
        }
        else if (bp == BodyParts.body)
        {
            pbBody.Show();
        }
        else if (bp == BodyParts.legs)
        {
            pbLegs.Show();
        }
        else if (bp == BodyParts.arms)
        {
            pbArms.Show();
        }
        // something went wrong, let me know about it
        else {
            MessageBox.Show("Error: I can't determine the proper body part to draw.");
        }
    }
