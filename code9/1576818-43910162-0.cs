        public ActionResult SampleAction()
        {
            using(var context = new YourContext())
            {
               return View(context.Goods.Include("description").First()); // for example    
            }          
        }
