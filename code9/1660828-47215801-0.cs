            protected void Page_PreInit(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                string ScheduleIdHF = string.Empty;
                if (Session["ScheduleIdHF"] != null)
                {
                    ScheduleIdHF = Session["ScheduleIdHF"].ToString();
                    CreateControls(ScheduleIdHF);
                    ...
                }
            }
        }
