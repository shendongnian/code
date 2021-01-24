    public ActionResult Edit(MappingObject mo)  {
      if(mo != null && mo.cSelectlist){
        foreach(SelectListItem cc in mo.cSelectlist){
           if(cc != null){
            Debug.WriteLine("Selected value is " +cc.Text);
           }  
        }
       }
      return View();
    }
