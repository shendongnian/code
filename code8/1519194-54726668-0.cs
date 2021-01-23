    using System.Data.OleDb;   //other standard namespaces needed also.   
    public class AccessDataHelper
    {
        string myConn;  //value set in this class constructor
        
         //Constructor
        public AccessDataHelper()
        {
            myConn = System.Configuration.ConfigurationManager.ConnectionStrings["LocalDB"].ToString();
            //If myConn is null, then a real problem.
        }
       
        public List<KAddress> GetUnvalidatedAddresses()
        {
            List<KAddress> kAddresses = new List<KAddress>();
            string sqlCommandText = String.Empty;
            using (OleDbConnection myOleDbConnection = new OleDbConnection())
            {
                if (myConn != null)
                {
                    myOleDbConnection.ConnectionString = myConn;
                    sqlCommandText = "SELECT tblAddresses.AddressId, " +
                        "tblAddresses.USPSValidated, tblAddresses.Notes, " +
                        "tblAddresses.Address, tblAddresses.City, tblAddresses.State, tblAddresses.ZIP " +
                        "FROM tblAddresses  " +
                        "WHERE ( ((IsNull(tblAddresses.USPSValidated)) Or ((tblAddresses.USPSValidated) <> 1)) ) ";
                        //Field USPSValidated is an integer 1=USPS valid address
                    OleDbCommand oleDbCommand = new OleDbCommand(sqlCommandText, myOleDbConnection);
                    oleDbCommand.Connection.Open();
                    OleDbDataReader reader = oleDbCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        KAddress kAddress = new KAddress();
                        kAddress.AddressID = Convert.ToInt32(reader["AddressID"]);
                        kAddress.Notes = reader["Notes"].ToString();    // Notes is a memo,long text field in Access
                        kAddress.Address = reader["Address"].ToString();
                        kAddress.City = reader["City"].ToString();
                        kAddress.State = reader["State"].ToString();
                        kAddress.Zip = reader["Zip"].ToString();
                        kAddresses.Add(kAddress);
                    }
                }
            }
            return kAddresses;
        }
    } //end of class
