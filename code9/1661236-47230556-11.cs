    private void CheckedChanged(CheckBox box)
    {
        if (box.Checked)
            butInstall.Enabled = true;
        else if (!boxes.Any(box => box.Checked))
            butInstall.Enabled = false;
    }
