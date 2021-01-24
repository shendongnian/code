    if (Session["ClaimDate"] != null)
                    {
                        DateTime day;
                        CultureInfo ci = CultureInfo.CurrentCulture;
                        DateTimeFormatInfo dtfi = ci.DateTimeFormat;
                        string[] SystemDateTimePatterns = new string[250];
                        int i = 0;
                        foreach (string name in dtfi.GetAllDateTimePatterns('d'))
                        {
                            SystemDateTimePatterns[i] = name;
                            i++;
                        }
                        string[] myDateTimeFormat = { "dd-MMM-yy", "dd-MMM-yyyy" };
        
                        if (myDateTimeFormat[0].Equals(SystemDateTimePatterns[0]) || myDateTimeFormat[1].Equals(SystemDateTimePatterns[0]))
                        {
                            day = DateTime.ParseExact(Session["ClaimDate"].ToString(), "dd/MM/yyyy", null);
                        }
                        else
                        {
                            day = DateTime.Parse(Session["ClaimDate"].ToString());
                        }
                        //   DateTime day = Convert.ToDateTime(Session["ClaimDate"].ToString());
                        ddlDay.Items.FindByValue(day.Day.ToString("00")).Selected = true;
                    }
                    else
                    {
                        ddlDay.Items.FindByValue(DateTime.Now.Day.ToString("00")).Selected = true;
                    }``
