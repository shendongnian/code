    public static DataView ElecDv480V(System.Data.DataTable dt)
        {
                System.Data.DataView dv = new DataView(dt);
                dv.RowFilter = "F1 = '480V'";
                dv.Sort = "F2 ASC, F3 ASC";                           
                System.Data.DataTable dt480 = dv.ToTable();   
                return dv;                                
    
        }
