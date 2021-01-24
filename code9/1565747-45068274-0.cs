    Jquery :
    
     <script type="text/javascript">
            $(document).ready(function () {
                $.ajax({
                    url: 'JqueryDataTable.aspx/GetState',
                    contentType: 'application/json; charset=utf-8',
                    method: 'POST',
                    dataType: 'JSON',
                    success: function (data) {
                        $('#tblState').DataTable({
                            data: jQuery.parseJSON(data.d),
                            sort: true,
                            searching: true,
                            columns: [
                        { 'data': 'StateId' },
                        { 'data': 'StateName' },
                        { 'data': 'IsUnionTerritory' }
                        ]
                        });
                    }
                });
            });
        </script>
    CS:
    
    [WebMethod]
        public static string GetState()
        {
            string cs = ConfigurationManager.ConnectionStrings["conString2"].ConnectionString;
            List<State> stateList = new List<State>();
            using(SqlConnection con=new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("SELECT StateId,StateName,IsUnionTerritory FROM State_Master ORDER BY StateName ASC", con);
                cmd.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    State objState = new State();
                    objState.StateId = Convert.ToInt32(dr["StateId"]);
                    objState.StateName = dr["StateName"].ToString();
                    objState.IsUnionTerritory = Convert.ToBoolean(dr["IsUnionTerritory"]);
                    stateList.Add(objState);
                }
            }
            JavaScriptSerializer js = new JavaScriptSerializer();
            return js.Serialize(stateList);
        }
    
        public class State
        {
            public int StateId { get; set; }
            public string StateName { get; set; }
            public bool IsUnionTerritory { get; set; }
        }
