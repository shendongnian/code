    protected void Page_Load(object sender, EventArgs e)
            {
                if(Session["evrno"] != null)
                   Session["evrno"] = 21006;
                int evrno;
                string EVRAKNO = "SP-";
                if (Page.IsPostBack == false)
                {
                    evrno = Convert.ToInt32(Session["evrno"].ToString());
                    evrno = evrno + 1;    
                    Session["evrno"] = evrno 
                }
        
                string EvrakNu = EVRAKNO + Convert.ToString(evrno);
                txt_EvrakNo.Text = EvrakNu;    
            }
