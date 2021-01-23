    protected void Page_Load(object sender, EventArgs e)
    {
         if(!IsPostBack)
         {
             //code here will be only executed the first time the page is loaded
             var q = from u in db.tbl_Subject select u;
             Paper_Subject.DataSource=q.ToList();
             Paper_Subject.DataTextField = "Subject_Name";
             Paper_Subject.DataValueField = "Subject_Id";
             Paper_Subject.DataBind();
             for (int i = 0; i <= 12;i++)
             {
                 if(i<10)
                     Paper_Duration_Hour.Items.Add("0"+i.ToString());
                 else
                     Paper_Duration_Hour.Items.Add(i.ToString());
             }
             for (int i = 0; i <= 60; i=i+5)
             {
                 if(i<10)
                     Paper_Duration_Minute.Items.Add("0"+i.ToString());
                 else
                     Paper_Duration_Minute.Items.Add(i.ToString());
             }
         }
        //code here will be executed every time page loaded
    }
