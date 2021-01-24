    pnl_assistance_seeking_IIGP_help.Visible = false;
    pnl_assistance_seeking_IIGP_Other.Visible = false;
    pnl_assistance_seeking_IIGP_Mentoring.Visible = false;
    string[] selectedvalues = assistance_seeking_IIGP.Split(',');
    for (int i = 0; i < selectedvalues.Length; i++)
    {
        selectedvalues[i] = selectedvalues[i].Trim();
        if (selectedvalues[i].ToString() == "Help with certification")
        {
         pnl_assistance_seeking_IIGP_help.Visible = true;
        }
        else if (selectedvalues[i].ToString() == "Other")
        {
         pnl_assistance_seeking_IIGP_Other.Visible = true;
        }
        else if (selectedvalues[i].ToString() == "Mentoring")
        {
          pnl_assistance_seeking_IIGP_Mentoring.Visible = true;
        }
    }
