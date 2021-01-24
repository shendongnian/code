    private void CheckedChanged(CheckBox box)
    {
        if (box.Checked == true)
            butInstall.Enabled = true;
        else if
            (boxChrome.Checked == false & 
            boxAdobeReader.Checked == false & 
            boxESET.Checked == false & 
            boxiTunes.Checked == false & 
            boxQuicktime.Checked == false & 
            boxTeamviewer.Checked == false & 
            boxWinrar.Checked == false & 
            boxVLC.Checked == false)
            butInstall.Enabled = false;
    }
    private void boxChrome_CheckedChanged(object sender, EventArgs e) =>
      CheckChanged(boxChrome);
    private void boxAdobereader_CheckedChanged(object sender, EventArgs e) =>
      CheckChanged(boxAdobeReader);
