         namespace service
       {
            public class Service1 : IService1, IService2
            {
        
            [WebInvoke(UriTemplate = "ADDStudent", Method = "POST", ResponseFormat = WebMessageFormat.Json)]
            public void AddStudent(StudentDetails sd)
            {
                string constr = ConfigurationManager.ConnectionStrings["mine"].ConnectionString;
                SqlConnection con = new SqlConnection(constr);
               //rest of the code
            }
    }
