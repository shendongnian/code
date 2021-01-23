    using System;
    using System.IO;
    using System.Collections.Generic;
    
    using CrystalDecisions.CrystalReports.Engine;
    using CrystalDecisions.Shared;
    
    using iTextSharp.text;
    using iTextSharp.text.pdf;
    Step  1:  Reference code 
    
            //reploace this event to your related event .......
            protected void Page_Load(object sender, EventArgs e)
            {
                //hold the more than one report outputs [bytes]
                List<byte[]> files = new List<byte[]>();
    
                //for testing purpose LOOP used,
                //u can change as per your requirement and your report name
                for (int i = 1; i <= 2; i++) {
    
                    ReportDocument crdReport1 = new ReportDocument();
                    
                    //put your related report names.....
                    crdReport1.Load(Server.MapPath(string.Format("CrystalReport{0}.rpt", i)));
    
                    Stream stream1 = crdReport1.ExportToStream(ExportFormatType.PortableDocFormat);
    
                    //prepare the "bytes" from "stream"               
                    files.Add(PrepareBytes(stream1));
                    //finally the result added to LIST
                }
    
                Response.Clear();
                Response.Buffer = true;
                Response.ContentType = "application/pdf";     
                
                //merge the all reports & show the reports            
                Response.BinaryWrite(MergeReports(files).ToArray());
    
                Response.End();        
            }
