        [HttpPost]
        public void Post([FromBody] SchemeMasterViewModel schemeMaster)
        {
            if (ModelState.IsValid)
            {
                var mappedresult = AutoMapper.Mapper.Map<SchemeMaster>(schemeMaster);
            }
        }
    
