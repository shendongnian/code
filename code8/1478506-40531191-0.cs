    public Dictionary<string, object> getPICv2(string Tdate_d, string Ddl_fampic, string Ddl_donnee, string Ddl_detail, string Ddl_caracteristique, string Ddl_poste, string Ddl_ilot, string Ddl_nposte, string Ddl_atelier, string Ddl_tposte)
            {
                Dictionary<string, object> list = new Dictionary<string, object>();
    
                SqlDataAdapter dac, dad, dam;
                DataSet dsm = new DataSet();
                DataSet dsp = new DataSet();
                DataSet dsd = new DataSet();
                DataSet dsc = new DataSet();
                DataSet dsb = new DataSet();
                DataTable dtm = new DataTable();
                DataTable dtc = new DataTable();
                DataTable dtv = new DataTable();
                DataTable dts = new DataTable();
                DataTable dtp2 = new DataTable();
                DataTable dtp3 = new DataTable();
                
    
                SqlConnection cn, cn1;
                SqlCommand cmd1;
                string sql = "", test = "";
    
                cn = new SqlConnection(CS_PMI);
                cn.Open();
    
                cn1 = new SqlConnection(CS_DW);
                cn1.Open();
                sql = "";
    
    
                // entête
    
                // lecture des mois sur la période
    
                sql = "SELECT year(CAKJDATE),convert(varchar,DateName( month , DateAdd( month , month(CAKJDATE) , -1 ))),'01/'+substring(CAKJDATE,5,2)+'/'+substring(CAKJDATE,1,4),COUNT(*)  ";
                sql = sql + "FROM [PMI].[dbo].[CALEND] ";
                sql = sql + "where CAKTSOC='100' and CAKTTYPE='01' and CAKTCODE='' and CACTACTIF='O' ";
                sql = sql + "and cast(CAKJDATE as datetime)>=convert(varchar,'" + Tdate_d + "',103) and cast(CAKJDATE as datetime)< convert(varchar,cast('" + Tdate_d + "' as datetime)+390,103) ";
                sql = sql + "group by convert(varchar,DateName( month , DateAdd( month , month([CAKJDATE]) , -1 ))),month([CAKJDATE]),year([CAKJDATE]),'01/'+substring(CAKJDATE,5,2)+'/'+substring(CAKJDATE,1,4) ";
                sql = sql + "order by year([CAKJDATE]),month([CAKJDATE]); ";
    
    
                try
                {
                    dam = new SqlDataAdapter(sql, cn);
                    dsm = new DataSet();
                    dam.Fill(dsm, "lstmois");
                    dtm = dsm.Tables["lstmois"];
    
                    //Lblerreur.Text = dtm.Rows[1][2].ToString();
                }
                catch (SqlException e)
                {
                    
                    cn.Close();
                    cn1.Close();
                }
    
                // construction ligne entete du tableau
                sql = "(SELECT 'Périodes' as entite,'" + dtm.Rows[0][0].ToString() + "<br>" + dtm.Rows[0][1].ToString() + "' as M01,'" + dtm.Rows[1][0].ToString() + "<br>" + dtm.Rows[1][1].ToString() + "' as M02,'" + dtm.Rows[2][0].ToString() + "<br>" + dtm.Rows[2][1].ToString() + "' as M03,'" + dtm.Rows[3][0].ToString() + "<br>" + dtm.Rows[3][1].ToString() + "' as M04,'" + dtm.Rows[4][0].ToString() + "<br>" + dtm.Rows[4][1].ToString() + "' as M05,'" + dtm.Rows[5][0].ToString() + "<br>" + dtm.Rows[5][1].ToString() + "' as M06,'" + dtm.Rows[6][0].ToString() + "<br>" + dtm.Rows[6][1].ToString() + "' as M07,'" + dtm.Rows[7][0].ToString() + "<br>" + dtm.Rows[7][1].ToString() + "' as M08,'" + dtm.Rows[8][0].ToString() + "<br>" + dtm.Rows[8][1].ToString() + "' as M09,'" + dtm.Rows[9][0].ToString() + "<br>" + dtm.Rows[9][1].ToString() + "' as M10,'" + dtm.Rows[10][0].ToString() + "<br>" + dtm.Rows[10][1].ToString() + "' as M11,'" + dtm.Rows[11][0].ToString() + "<br>" + dtm.Rows[11][1].ToString() + "' as M12,'Total' as TT) ";
    
                try
                {
                    dad = new SqlDataAdapter(sql, cn);
                    //dsm = new DataSet();
                    dad.Fill(dsm, "entete");
    
                    List<string> ListEntete = new List<string>();
    
                    for (int i = 0; i <= 13; i++)
                    {
                        ListEntete.Add(dsm.Tables["entete"].Rows[0][i].ToString());
                    }
    
                    list.Add("entete", ListEntete);
                }
                catch (SqlException e)
                {
                    
                    cn.Close();
                    cn1.Close();
                }
