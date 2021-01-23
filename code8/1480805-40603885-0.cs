    protected void Page_Load(object sender, EventArgs e)
    {
            int evrno = 21006;
            string EVRAKNO = "SP-";
            //save initial value in Session
            if (Session["evrno"] == null)
            {
                Session["evrno"] = evrno;
            }
            if (Page.IsPostBack == false)
            {
                //used the value saved in Session
                evrno = Convert.ToInt32(Session["evrno"]) + 1;
            }
            string EvrakNu = EVRAKNO + evrno.ToString();
            //save NEW value in Session again
            Session["evrno"] = evrno;
            
            txt_EvrakNo.Text = EvrakNu;
            //Response.Write(EvrakNu);
    }
