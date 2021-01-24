    public class GetStudentsResponse
    {
        public bool IsSuccessful { get; set; }
    
        public string ErrorMessage { get; set; }
    
        public List<Student> Students { get; set; }
    }
    [WebMethod]
    public GetStudentsResponse getStudents(string schoolID, string authToken)
    {
        var response = new GetStudentsResponse();
        var authenticate = new Authenticate();
        var authorized = authenticate.ValidateAuthorizationToken(authToken);
    
        if (authorized)
        { 
             response.IsSuccessful = true;
             response.Students = GetStudents();
        }
        else
        {
             response.IsSuccessful = false;
             response.ErrorMessage = "Invalid token";       
        }
        return response;
    }
