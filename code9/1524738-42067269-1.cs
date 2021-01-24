       public ActionResult Test()
        {
            MyPerson mp= new MyPerson();
            
            var myTestObj = db.Persons.Find(1);// Say for test you are picking the person obj where the primary key is 1.
            var testOtherInfo = db.tblOtherInfoDetailss.ToList();
            Dictionary<string, string> values = JsonConvert.DeserializeObject<Dictionary<string, string>>(myTestObj.OtherInfo);
            mp.Name = myTestObj.Name;
            mp.KeyVal = new Dictionary<string, string>();
            foreach (var i in testOtherInfo)
            {
             
                var value = values.Where(a => a.Key == i.Name).First().Value;
                mp.KeyVal.Add(i.Name, value);
            }
            return View(mp);
        }
