     using System;
     using System.Collections.Generic;
     using System.Linq;
     using System.Web;
     using System.Web.UI;
     using System.Web.UI.WebControls;
     using System.Drawing;
     using System.Text;
     using System.Net;
     using System.IO;
     using WebSupergoo.ABCpdf8;
     namespace ABCpdfExamples
    {
         public partial class test : System.Web.UI.Page
       {
              protected void Page_Load(object sender, EventArgs e)
             {           
                // ---- Adds a font reference to the document ----
                Doc doc = new Doc();
                doc.FontSize = 48;
                string theFont = "Times-Roman ";
                doc.Font = doc.AddFont(theFont);
                doc.AddText(theFont);
                theFont = "Helvetica-Bold";
                doc.Font = doc.AddFont(theFont);
                doc.AddText(theFont);
                doc.Save(Server.MapPath("~/Results/Output.pdf"));
                doc.Clear();
             }
         }
     }
