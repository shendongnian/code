        public ActionResult  Get(int id)
        {
            var myObj= _testRepository.TryGetById(id);
            if (myObj== null)
            {
                return new NotFoundResult();
            }
            return new ContentResult{ContentType="application/json", Content=DoMySerialize(myObj)}; 
        
        }
