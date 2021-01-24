    private void scrollRightButton_Click(object sender, EventArgs e)  
    {
        int threshhold = cats.Count - 3;
        if (shiftCount < threshhold)
        {
            shiftCount++;
            for (int i = 0; i < buttonList.Count; i++)
            {
                listEntry = cats[i + shiftCount];
                buttonList[i].Text = listEntry;
            }
            Console.Write(shiftCount);
        }
    }
