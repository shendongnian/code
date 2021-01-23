    using System.Text;
    var builder = new StringBuilder();
    
    foreach (var item in dir3)
         {
               builder.Append(item.html_instructions);
               builder.Append("<br />");
         }
    
    resultDirectionHtml = builder.ToString();
