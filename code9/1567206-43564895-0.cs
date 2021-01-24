    public class ReturnOrder
    {
        public string Message;
        public int QtqSlit;
        public int QtyPcs;
        public string Design;
    
    
    }
    
    
    [WebMethod(MessageName = "OrderStatus", Description = "OrderStatus new Order")]
    [System.Xml.Serialization.XmlInclude(typeof(List<ReturnOrder>))]
    public List<ReturnOrder> OrderStatus(string JO)  /// get list of notes
    {
        List<ReturnOrder> result=new List<ReturnOrder>();
        int QtqSlit = 0;
        int QtyPcs = 0;
        String Design = "";
        string Message = "";
    
        //try
        //{
            SqlDataReader reader;
            using (SqlConnection connection = new SqlConnection(DBConnection.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT QtqSlit,QtyPcs,Design  FROM TestOrderStatus where JO=@JO");
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connection;
                cmd.Parameters.AddWithValue("@JO", JO);
                connection.Open();
    
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                        QtqSlit = reader.GetInt32(0);
                        QtyPcs = reader.GetInt32(1);
                        Design = reader.GetString(2);
                 
        ReturnOrder rt = new ReturnOrder();
        rt.Message = Message;
        rt.QtqSlit = QtqSlit;
        rt.QtyPcs = QtyPcs;
        rt.Design = Design;
    result.add(rt);
   
                }
                if (QtqSlit == 0)
                {
                    Message = " user name or password is in correct";
                }
                reader.Close();
    
                connection.Close();
            }
    
        //}
        //catch (Exception ex)
        //{
        //    Message = " cannot access to the data";
        //}
    
    
        
    
        return result;
    }
