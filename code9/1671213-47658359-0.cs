    <%@ Page Language="C#" %>
    <%@ import namespace="System.Data"%>
    <%@ import namespace="System.Data.SqlClient"%>
    <%@ import namespace="System.IO" %>
    <%@ import namespace="System.Web" %>
    <%@ import namespace="System.Web.Script.Serialization" %>
    
    <script runat="server">
    
        public class MessageClass
        {
            public string type;
            public string text;
            public string url;
            public string user_name;
            public long timestamp;
        }
        
    </script>
    
    
    <%
    
    
    
    // GET THE CONTENT THAT WAS POSTED
    StreamReader reader = new StreamReader(HttpContext.Current.Request.InputStream);
    string requestFromPost = reader.ReadToEnd();
    
    
    
    // DESERIALIZE THE CONTENT
    JavaScriptSerializer ser = new JavaScriptSerializer();
    var response = ser.Deserialize<MessageClass>(requestFromPost);
