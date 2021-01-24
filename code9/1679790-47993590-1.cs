    var generatedCode = 
    @"
        namespace MyProject
        {
            public class MyClass
            {
                public void GetAllScripts()
                {
                    // ...
                }
            }
        }
    ";
    var generatedPage = 
    @"
        <%@ Page Language=""C#"" AutoEventWireup=""true"" %>
        <html>
        <head>
            <title>Test</title>
            <script language=""CS"" runat=""server"" >
                void Page_Load(object sender, EventArgs e)
                {
                    //below code will be executed when the page is opened
                    MyClass myclass = new MyClass();// backend class
                    myclass.GetAllScripts();
                }
            </script>
        </head>
        <body>
            ...
        </body>
        </html>
    ";
     
    // change to the path and file name to fit your need, but the cs file must in ~/App_Code
    var aspxPath = Path.Combine(Server.MapPath("~"), "GeneratedPage.aspx");
    System.IO.File.WriteAllText(aspxPath, generatedPage);
    var csPath = Path.Combine(Server.MapPath("~/App_Code"), "MyClass.cs");
    System.IO.File.WriteAllText(csPath, generatedCode);
    
