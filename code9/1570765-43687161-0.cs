            var _objAdd = new C();
            var Get_ClientInfor = example();
            var _obj = new List<C>();
            foreach (var item in Get_ClientInfor)
            {
             
                _objAdd.FirstName = item.Clients.FirstName;
                _objAdd.LastName = item.Clients.LastName;
                if (item.Clients.DateBirth != null)
                {
                    _objAdd.Dob = item.Clients.DateBirth.Value;
                }
                _objAdd.Gender = item.ClientDemographics.Gender;
                _obj.Add(_objAdd);
            }
                return View(_obj);//error ===>>
`
