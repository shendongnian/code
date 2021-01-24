    I hope this will help anyone in same situation(i.e. learners!). After hunting around I realised that if (I could be wrong!) working with complex objects such as images text will just be strung along anyway with the .Add and .Save as long as they're part of the Model like so:
    namespace client.Models
    {
        using System;
        using System.Collections.Generic;
        
        public partial class jobs
        {
            public int id { get; set; }
            public string name { get; set; }
            public Nullable<bool> iscomplete { get; set; }
            public Nullable<int> jobbyuserid { get; set; }
            public Nullable<int> responsibletradesmanid { get; set; }
            public string jobmessage { get; set; }
            public string stage { get; set; }
            public string startjob { get; set; }
            public int ImageId { get; set; }
            public string ImageName { get; set; }
            public string ImageAlt { get; set; }
            public byte[] ImageData { get; set; }
            public string ContentType { get; set; }
            public string Budget { get; set; }
        }
        }
    
    Then chop up the Action to create,hold,save,image data etc but MOST IMPORTANTLY you do not need to define any fields from the form 
       `(string quoteSearch = Request["quoteSearch"]; etc.)` as they will be updated with the model. So the only difference here is that I have removed the form requests and removed saving single items like  
    
          //Save model object to database
                        db.jobs.Add(new jobs
                        {
                            name = jobname,
    
    and then only used one action for both image and form data all put together nicely like so:
       
    
     
    
         [AcceptVerbs(HttpVerbs.Post)]
         public ActionResult Create(jobs pic, HttpPostedFileBase image)
         {
         var context = System.Web.HttpContext.Current;
        var contextBase = new HttpContextWrapper(context);
        ////Pull out the current username from cookie into var
        //usernameCookie = new HttpCookie("CurrentUsername");
        //usernameCookie = contextBase.User.Request.Cookies["CurrentUsername"];
    
            //Get email from OWIN
            string usernameCookie = contextBase.User.Identity.Name.ToString();
    
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    //attach the uploaded image to the object before saving to 
        
    
            Database
                        pic.ContentType = Convert.ToString(image.ContentLength);
                        pic.ImageData = new byte[image.ContentLength];
                        image.InputStream.Read(pic.ImageData, 0, 
           image.ContentLength);
        
                        //Save image to file
                        var filename = image.FileName;
                        var filePathOriginal = 
           Server.MapPath("/Content/Uploads/Originals");
                        var filePathThumbnail = 
           Server.MapPath("/Content/Uploads/Thumbs");
                        string savedFileName = Path.Combine(filePathOriginal, 
           filename);
                        image.SaveAs(savedFileName);
        
                        //Read image back from file and create thumbnail from it
                        var imageFile = 
            Path.Combine(Server.MapPath("~/Content/Uploads/Originals"), filename);
                        using (var srcImage = Image.FromFile(imageFile))
                        using (var newImage = new Bitmap(100, 100))
                        using (var graphics = Graphics.FromImage(newImage))
                        using (var stream = new MemoryStream())
                        {
                            graphics.SmoothingMode = SmoothingMode.AntiAlias;
                            graphics.InterpolationMode = 
            InterpolationMode.HighQualityBicubic;
                            graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                            graphics.DrawImage(srcImage, new Rectangle(0, 0, 100, 
             100));
                            newImage.Save(stream, ImageFormat.Png);
                            var thumbNew = File(stream.ToArray(), "image/png");
                            pic.ImageData = thumbNew.FileContents;
                            pic.ImageName = filename;
                        }
                    }
        
                    //Save model object to database
                    db.jobs.Add(pic);
        
                    ViewBag.Message = "Image Uploaded Successfully!!";
        
                    int newJobID = 0;
        
                    try
                {
                    //this saves model with image
                    db.SaveChanges();
    
                    //get last inserted row ID
                    newJobID = pic.id;
    
                    //get row based on last inserted for updating the imageID as we want them correlate
                    // make sure you have the right column/variable used here
                    var rowToUpdate = db.jobs.FirstOrDefault(x => x.id == newJobID);
                    if (rowToUpdate == null) throw new Exception("Invalid id: " + newJobID);
                    // this variable is tracked by the db context
                    rowToUpdate.ImageId = newJobID;
    
                    var addLoggedInUserToTable = db.tradesusers.FirstOrDefault(e => e.email == usernameCookie);
                    if (addLoggedInUserToTable == null) throw new Exception("Invalid id: " + usernameCookie);
                    addLoggedInUserToTable.lastpostedjobid = newJobID;
    
                    if (addLoggedInUserToTable.email == usernameCookie) { 
                    rowToUpdate.jobbyuserid = addLoggedInUserToTable.id;
                }
    
                    //reasave Model with updated ID
                    db.SaveChanges();
    
                }
                catch (DbEntityValidationException e)
                {
                    foreach (var eve in e.EntityValidationErrors)
                    {
                        Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                            eve.Entry.Entity.GetType().Name, eve.Entry.State);
                        foreach (var ve in eve.ValidationErrors)
                        {
                            Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                                ve.PropertyName, ve.ErrorMessage);
                        }
                    }
                    throw;
                }
    
                ViewBag.Message = "Image Uploaded Successfully!!";
    
                //return View("JobDetails");
                return RedirectToAction("PersonalDetails", new { usernameCookie = usernameCookie });
    
            }
    
            return View("JobDetails");
        }`enter code here`
    
    I believe retrieving the images is a bit more straight forward! ;-)
