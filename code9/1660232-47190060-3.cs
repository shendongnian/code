    public ActionResult OpenImagePopUp(int? id)
            {
                if (id != null)
                {
                    string html = string.Empty;
                    Help request2 = new Help();
                    request2.id = id;
                    var response = apiHelp.GetHelpRecords(request2);
                    if (response.Error != null)
                    {
                        ErrorLogRequest errorReq = new ErrorLogRequest()
                        {
                            LogDate = DateTime.Now,
                            LogMethod = "GetHelpRecords",
                            LogPage = "Canopy Help",
                            LogPerson = User.Identity.Name,
                            LogInfo = response.Error.ErrorCode + " " + response.Error.ErrorMessage + " " + response.Error.ExceptionObject.Message
                        };
                        apiErrorLog.InsertErrorLog(errorReq);
                    }
                    var helpRecords = response.data.Select(s => new Help()
                    {
                        id = s.id,
                        Image = s.Image
    
                    }).Where(w => w.id == id).FirstOrDefault();
    
                    if (helpRecords.Image != null)
                    {
                        var base64string = Convert.ToBase64String(helpRecords.Image);
                        request2.ImgSrcBase64 = string.Format("data:image/gif;base64,{0}", base64string);
    
                        html = string.Format("<img id='imgPopUp' src='{0}' alt='Image'/>", request2.ImgSrcBase64);
    
                        return Content(html, "text/html");
                    }
                    else
                    {
                        html = "<h4>This record has no image attached!</h4>";
                        return Content(html, "text/html");
                    }
                }
                else return new EmptyResult();
            }
