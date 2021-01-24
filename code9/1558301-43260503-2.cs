        protected void Page_Load(object sender, EventArgs e)
                {
                    if (!IsPostBack)
                    {
    
                       GestorBD = new GestorBDT.GestorBD("MSDAORA", "fs", "pass", "oracle");
                       cadsql = "SELECT * FROM PCArticulos";
                       GestorBD.queryDB(cadsql, "arts", DsGeneral);
                       c.loadDropDownList(DDLArticulos, DsGeneral, "arts", "nombre");
                    }
                    if (Session["TA"] != null)
                    {
                        tablaPed.Rows.AddRange(((List<TableRow>)Session["TA"]).ToArray());
                    }
                }
