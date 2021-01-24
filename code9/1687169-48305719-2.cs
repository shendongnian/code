    public class Class{
        static string str = Properties.Settings.Default.ConnectionString;
        SqlConnection con = new SqlConnection(str);
    
        public void method(){
            try{
                con.Open();
                SqlCommand cmd = new SqlCommand("StoredProcedure", con);
                cmd.CommandType = CommandType.StoredProcedure;
            }catch{
            /**/
            }finally{
                con.Close()
            }
        }
    }
