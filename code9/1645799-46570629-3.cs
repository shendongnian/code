    public ActionResult FilterByColumn(String ColumnName)
            {  
                ViewBag.searchval = "";   
                string SearchValue = Request.Form["SearchValue"];
                if (SearchValue != "" )
                {
                    List<Country> result = new List<Country>();
                    result = db.Countries.ToList();
                    result = db.Countries.Where(ColumnName + ".Contains" + "(\"" + SearchValue.ToLower() + "\")").ToList();
                    ViewBag.searchval = SearchValue; 
                    return View(result);
                }
                return RedirectToAction("Index");
            }
