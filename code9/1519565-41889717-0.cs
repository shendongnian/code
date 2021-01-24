    <%@ Page Language="C#" Debug="true" %>
    <%@ Import Namespace="System.Net" %>
    <%@ Import Namespace="System.IO" %>
    <%@ Import Namespace="System.Text" %>
    <%@ Import Namespace="System.Xml" %>
    <%@ Import Namespace="System.Data" %>
    
    <script type="text/c#" runat="server">
        public class AddressSummary
        {
            public string id { get; set; }
            public string txt { get; set; }
        }
    </script>
    
    <%
        // Create an instance of the class declared above
        var a = new AddressSummary();
    %>
