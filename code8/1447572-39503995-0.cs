    public void ExportToExcel(string grupString)
           {
                var student = (List<Student>)Session["student"];
                var groups = db.Grupa.ToList();
                var result = (from e in student
                              select new
                              {
                                  Nume = e.Nume,
                                  Prenume = e.Prenume,
                                  Nota = e.Nota,
                                  Grupa = e.Grupa.Specialitate + " " + e.Grupa.Numar,
                                  Conducator = e.Conducator.Nume+" "+ e.Conducator.Prenume,
                                  Tpractica = e.Tpractica.Tip,
                                  Perioada = e.Perioada.An,
                                  LocPractica = e.LocPractica.Denumire,
                              }).ToList();
                                   
    
    
                var gv = new GridView();
    
                gv.DataSource = result;
    
    
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
