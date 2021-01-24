    [HttpPost]
        public ActionResult Delete(int[] id)
        {
            foreach (var item in id)
            {
                try
                {
                    jobProvider.Delete(item);                 
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return RedirectToAction("Index");
        }
