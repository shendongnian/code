    public ActionResult Edit(int id)
     {
         try
         {
                if (id != 0 || id!=null)
               {
                string result = _foodAppService.GetById(id);
                FoodVm food = string.IsNullOrEmpty(result) ? null:JsonConvert.DeserializeObject<FoodVm>(result);
        
                if (food == null)
                {
                    return RedirectToAction("Index");
                }
                else
                {    
                return View(food);
                }
              }
             else
              {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
              }
        }
        catch (exception ex)
        {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
    }
