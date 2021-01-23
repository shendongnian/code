    Cursus cursus = DWE.Cursus.Include(x => x.CursusWeek).FirstOrDefault(x => x.Naam == CurNaam);
    
    if (cursus != null)
    {
    	TbNaam.Text = CurNaam;
    	TbOmschrijving.Text = cursus.Omschrijving;
    	CmbSelBoot.SelectedValue = cursus.BootID;
    	TbPrijs.Text = cursus.Prijs.ToString();
    	
    	var cursusWeek = cursus.CursusWeek;
    	
    	if (cursusWeek != null)
    	{
    		BeginDate.SelectedDate = Utils.UnixTimeStampToDateTime(cursusWeek.Begint);
    		Enddate.SelectedDate = Utils.UnixTimeStampToDateTime(cursusWeek.Eindigt);
    	}
    }
    else
    {
       // show a message about Cursus not found here..
    }
