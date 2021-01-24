        [HttpPost]
        public ActionResult ActionName(Model model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //Create SQL class and write your method (insert, update or delete etc.).
                    bool check = SQLManager.Check(model);
                    if (check)
                    {
                      //Make something
                    }
                    else
                    {
                        //Return error
                        return View("Index");
                    }
                }
                catch (Exception ex)
                {
                    
                    //Return error
                    return View("Index");
                }
            }
            else
            {   
                //Return error
                return View("Index");
            }
        }
