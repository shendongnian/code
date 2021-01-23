    protected void Page_Load(object sender, EventArgs e)
        {
            //Set default initial value in session
            int evrno = (Session["evrno"] != null && Session["evrno"].ToString() != string.Empty) ? Convert.ToInt32(Session["evrno"]) : 021006;
            string EVRAKNO = "SP-";
            if (!Page.IsPostBack)
            { 
                //get value saved in Session
                evrno = evrno + 1;
                //set save new value in session
                Session["evrno"] = evrno;
            }
            string EvrakNu = EVRAKNO + Convert.ToString(evrno);
            txt_EvrakNo.Text = EvrakNu;
        }
