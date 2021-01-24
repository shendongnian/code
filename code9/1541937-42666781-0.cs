    public ActionResult Opis(string somethingToFind)
        {
            string pathToOpis = Server.MapPath(Url.Content(@"~/Views/Home/opisy"));
            pathToOpis = pathToOpis + @"\" + somethingToFind + ".rtf";
                try 
                {
                    System.IO.StreamReader file = new System.IO.StreamReader(pathToOpis);
                    RtfPipe.Support.RtfSource source = file.ReadToEnd();
                    MyModel.Opis = Rtf.ToHtml(source);
                }
                catch
                {
                    MyModel.Opis = "some communicate";
                }
                
                return View(MyModel); 
      }
        
