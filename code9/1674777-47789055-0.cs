    Hi You can try the below code sample.
     
                int items = 10; //ListBoxItems.Items.Count;
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < items; i++)
                {
    
                    sb.AppendLine(i.ToString()); //Loop through and get list box item values
                }
    
                Response.Clear();
                Response.AddHeader("content-disposition", "attachment;filename=ListBox_Contents.csv");
                Response.Charset = "";
                Response.ContentType = "application/vnd.csv";
                StringWriter stringWrite = new StringWriter(sb);
                HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
                Response.Write(stringWrite.ToString());
                Response.End(); 
