    var generatedCode = 
    @"
        namespace MyProject
        {
            public class MyClass
            {
                public static string SomeMethod()
                {
                    return ""From Generated Class"";
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
        </head>
        <body>
            <div>
                <%-- Call function in generated class --%>
                <%=MyProject.MyClass.SomeMethod() %>
            </div>
        </body>
        </html>
    ";
     
    // change to the path and file name to fit your need, but the cs file must in ~/App_Code
    var aspxPath = Path.Combine(Server.MapPath("~"), "GeneratedPage.aspx");
    System.IO.File.WriteAllText(aspxPath, generatedPage);
    var csPath = Path.Combine(Server.MapPath("~/App_Code"), "MyClass.cs");
    System.IO.File.WriteAllText(csPath, generatedCode);
    
