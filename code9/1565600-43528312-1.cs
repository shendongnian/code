            public void SaveXmlToDb(List<DmgRegisterVM> dmgRegList)
        {
            //from list to database
            foreach (var item in dmgRegList)
            {
                var model = Mapper.Map<DmgRegister>(item);
                DmgRegister.Add(model);
                SaveChanges();         
            }
        }
