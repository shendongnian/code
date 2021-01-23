        public string un { get; set; } 
        public string pwd { get; set; }
   }
    [WebMethod]
        public static string LoginSer(Login user)
        {
    
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("select Username,Password from emp_Login where IsActive=1 and Username='" + user.un + "' and Password='" + user.pwd + "'", con))
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        return "1";
                    }
                    else
                    {
                        return "0";
                    }
                }
            }
    
        }
    $(document).ready(function () {
    $("#btnLogin").click(function () {
        var uid = $("#txtUN").attr('value');
        var pass = $("#txtPWD").attr('value');
        var userdata = {
                "un": uid,
                "pwd": pass
            };		
        $.ajax({
            type: "POST",
            url: "Login.aspx/LoginSer",
            data: userdata,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                if (data.d == "1")
                {
                    window.location.assign("../../Home.aspx");
                }
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                //alert(XMLHttpRequest.responseText);
                var err = eval("(" + XMLHttpRequest.responseText + ")");
                alert(err.Message);
            }
    
        });
    
    });
    });
