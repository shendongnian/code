    Cursus cursus = DWE.Cursus.FirstOrDefault(x => x.Naam == CurNaam);
    
    if (cursus != null)
    {
    	TbNaam.Text = CurNaam;
    	TbOmschrijving.Text = cursus.Omschrijving;
    	CmbSelBoot.SelectedValue = cursus.BootID;
    	TbPrijs.Text = cursus.Prijs.ToString();
    	
    	var cursusWeek = DWE.CursusWeeks.FirstOrDefault(x => x.CursusId = cursus.CursusId);
    	
    	if (cursusWeek != null)
    	{
    		BeginDate.SelectedDate = Utils.UnixTimeStampToDateTime(cursusWeek.Begint);
    		Enddate.SelectedDate = Utils.UnixTimeStampToDateTime(cursusWeek.Eindigt);
    	}
    }
