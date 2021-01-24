        var model = _TblUser.SingleOrDefault(x => x.UserName == type.UserName);
            var q = _TblGroupCities.Where(x => x.IdGroup == model.FkGroup && x.Active == true);
            tblCityViewModel = new List<MohasebKhodro.ViewModels.TblCityViewModel>();
            var sample2 =
                (from x in _TblCity
                 join a in _TblGroupCities on x.IdCity equals a.FkCity
                 where a.Active == true && a.IdGroup == model.FkGroup
                 select new
                 {
                     x.IdCity,
                     x.NameCity
                 }).ToList();
            foreach (var item in sample2)
            {
                var er = _TblCtrCar.Where(x => x.FkCity == item.IdCity).Max(x => x.CurYear);
                tblCityViewModel.Add(new MohasebKhodro.ViewModels.TblCityViewModel
                {
                    IdCity = item.IdCity,
                    NameCity = item.NameCity,
                    MaxCurrentYear = Convert.ToString(er)
                });
            }
