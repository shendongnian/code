    <%@ WebService Language="C#" Class="ValidateUser" %>
    using System;
    using System.Web;
    using System.Collections;
    using System.Web.Services;
    using System.Web.Services.Protocols;
    using System.Data;
    using System.Data.Odbc;
    using System.Web.Script.Serialization;
    using System.Web.Script.Services; 
    using UserSite.DataClasses;
    
    [WebService(Description = "Web services to query Username availability.", Namespace = "http://localhost")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ScriptService]
    public class ValidateUser: System.Web.Services.WebService
    {
    
        [WebMethod(Description = "Gets the availability of a username.")]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string GetUsernameAvailable(string username)
        {
    
            if (username == null)
            {
                username = "";
            }
            DbaseExecSpWithReturnValue Sproc = new DbaseExecSpWithReturnValue();
            Sproc.SetSp("sp_CheckUsernameAvailable");
            Sproc.AddParam(1);
            Sproc.AddParam("Username", SqlDbType.Char, username, 20);
            int RetVal = Sproc.Execute();
            Sproc.Close();
            if (RetVal == 0)
            {
                return @"{""available"": false}";
            }
            else
            {
                return @"{""available"": true}";
            }
    
        }
    }
    public bool GetUsernameAvailable(string username)
    {
       ...
       return (RetVal == 0) ? false : true;
    }
