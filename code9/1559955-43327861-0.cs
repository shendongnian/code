     public class ClassName
        {
            [Key]
            public int Id { get; set; }
            //other
            //field
    
            //Foreign key
            public string ApplicationUserId { get; set; }
        }
    
    Then go to your methods, try this, 
    
    [HttpGet]
     public ActionResult Add()
      {
     return View();
     }
    
    [HttpPost]
    public ActionResult Add(ClassName className){
    
    if (ModelState.IsValid)
                {
    className.ApplicationUserId=User.Identity.GetUserId();
    //rest of field
    //
    
    db.dbltable.Add(className);
    db.SaveChanges();
    
    }
  
