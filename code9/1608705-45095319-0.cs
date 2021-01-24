     public class Cars
        {
            public string carName;
            public string carRating;
            public string carYear;
        }
    //Your Webmethod*
    [WebMethod]
    public List<Cars> getListOfCars(List<string> aData)
    {
        SqlDataReader dr;
        List<Cars> carList = new List<Cars>();
    
        using (SqlConnection con = new SqlConnection(conn))
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "spGetCars";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@makeYear", aData[0]);
                con.Open();
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        string carname = dr["carName"].ToString();
                        string carrating = dr["carRating"].ToString();
                        string makingyear = dr["carYear"].ToString();
    
                        carList.Add(new Cars
                                        {
                                            carName = carname,
                                            carRating = carrating,
                                            carYear = makingyear
                                        });
                    }
                }
            }
        }
        return carList;
    }
    //*
    //Your Client Side code
        $("#myButton").on("click", function (e) {
            e.preventDefault();
            var aData= [];
            aData[0] = $("#ddlSelectYear").val(); 
            $("#contentHolder").empty();
            var jsonData = JSON.stringify({ aData:aData});
            $.ajax({
                type: "POST",
                //getListOfCars is my webmethod   
                url: "WebService.asmx/getListOfCars", 
                data: jsonData,
                contentType: "application/json; charset=utf-8",
                dataType: "json", // dataType is json format
                success: OnSuccess,
                error: OnErrorCall
            });
           
            function OnSuccess(response) {
              console.log(response.d)
            }
            function OnErrorCall(response) { console.log(error); }
            });
