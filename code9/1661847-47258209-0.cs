      public class DropDownConfiguration
            {
                public string Project { get; set; }
    
                public string LineID { get; set; }
    
                public SelectList dropDownSelectList{ get; set; }
    
            }
    [ActionName("DetailsForm")]
            [HttpGet]
            public ActionResult DetailsForm()
            {
                try
                {
                 DropDownConfiguration dropConfig = new DropDownConfiguration();
    
           IEnumrebale<DropDownConfiguration> selectList = floorService.DropDownList();
    
    
                    DetailsViewModel model = new DetailsViewModel()
                 {
    
                     dropConfig = selecrList ,
                 };
                    dropConfig.dropDownSelectList  = new SelectList(selectList, "Value", "Text");
                    return View("DetailsForm",model);
    
                }
                catch (Exception ex)
                {
                    return View("_error");
                }
    
            }
