    if (radioButton1.Checked)
    {
        toolStripMenuItem1.Available = toolStripMenuItem2.Available = true;
        toolStripMenuItem3.Available = false;
    }
    else if (radioButton2.Checked)
    {
        toolStripMenuItem1.Available = toolStripMenuItem2.Available = false;
        toolStripMenuItem3.Available = true;
    }
