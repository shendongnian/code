var content = _context.CR306000GetSchema(); _context.CR306000Clear();
var commands = new List();
ReqParameter(content, ref commands);
commands.Add(content.Actions.Save);
commands.Add(content.CaseSummary.CaseID);
var orderResults = _context.CR306000Submit(commands.ToArray());
private static void ReqParameter(CR306000Content content, ref List cmds) { if (cmds == null) throw new ArgumentNullException("cmds");
 private static void ReqParameter(CR306000Content content, ref List<Command> cmds)
        {
            if (cmds == null) throw new ArgumentNullException("cmds");        
              
            byte[] filedata= null;            
            Uri uri = new Uri("https://cdn.acumatica.com/media/2016/03/software-technology-industries-small.jpg");  // change the required url of the data that has to be fetched 
            
            if (uri.IsFile)
            {
                string filename = System.IO.Path.GetFileName(uri.LocalPath);
                filedata = System.Text.Encoding.UTF8.GetBytes(uri.LocalPath);
            }
            if (filedata == null)
            {
                WebClient wc = new WebClient();
                filedata = wc.DownloadData(uri);
            }
            cmds = new List<Command>
            {
                //Case Header Details
                new Value { Value="<NEW>",LinkedCommand = content.CaseSummary.CaseID},
                new Value { Value="L41",LinkedCommand = content.CaseSummary.ClassID},
                new Value { Value="ABCSTUDIOS",LinkedCommand = content.CaseSummary.BusinessAccount, Commit = true},          
                new Value { Value="Test subject created from envelop call 11C",LinkedCommand = content.CaseSummary.Subject},           
                // body of the case 
                new Value{Value= "Body of the content for created through envelop call 11B", LinkedCommand = content.Details.Description},
                         
                //Attaching a file
                new Value
                {
                    Value = Convert.ToBase64String(filedata),   // byte data that is passed to through envelop 
                    FieldName = "Test.jpg",
                    LinkedCommand =
                content.CaseSummary.ServiceCommands.Attachment
                },
               
             };
        }
Let me know if this works for you.
Thanks
