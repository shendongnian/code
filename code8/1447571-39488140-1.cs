    public void ExportToExcel()
            {
                var student = (List<Student>)Session["student"];
                var groups  = **YourDBContextGoesHere**.Groups.ToList();
                // extract new result from the student dbset and join it 
                // with groups dbset to get the name
                // Note: only one trip to the db to get the group names since
                //       the student already stored in the session
                var result  = from s in student
                              join g in groups on s.GroupID = g.GroupID
                              select new { // you can define a ModelView with whatever properties you want inside, but I will assume that you want the following
                                 Nume = s.Name,
                                 Prenume = s.Prenume,
                                 Nota= s.Nota,
                                 GrupaID = g.Name, // here you put the name of the group
                                 ConducatorID =s.ConducatorID,
                                 TPracticaID = s.TPracticaID,
                                 PerioadaID = s.PerioadaID ,
                                 StudentID = StudentID,
                              };
                var gv = new GridView();
                gv.DataSource =result.ToList(); // here you put the result
                gv.DataBind(); 
    
                Response.ClearContent();
                Response.Buffer = true;
                Response.AddHeader("content-disposition", "attachment; filename=DemoExcel.xls");
                Response.ContentType = "application/ms-excel";
                Response.Charset = "";
                StringWriter objStringWriter = new StringWriter();
                HtmlTextWriter objHtmlTextWriter = new HtmlTextWriter(objStringWriter);
                gv.RenderControl(objHtmlTextWriter);
                Response.Output.Write(objStringWriter.ToString());
                Response.Flush();
                Response.End();
            } 
