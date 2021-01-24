        [HttpPost]
        public ActionResult SubmitPartial([DynamicModelBinder] dynamic model)
        {
            // Our model.ToString() serialises it from the baseModel class
           var serialisedString = model.ToString();
            // do something .. echo it back for demo
           return Content(serialisedString);
        }
