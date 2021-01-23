     public override IList<PeopleViewModel> GetPeopleByPersonCode(int PersonCode)
        {
            IList<PeopleViewModel> _PeopleModel = null;
            IList<PeopleViewModel> _PeopleModel_b = null;
            using (var _uof = new FES_UOF())
            {
                _PeopleModel_b =   _uof.PeopleRepository.GetAll().Where(x => x.PERSON_CODE == PersonCode).Select( pl => new PeopleViewModel { People = pl}).ToList();
 
              //or
                _PeopleModel_b = (from pl in _uof.PeopleRepository.GetAll()
                                  where pl.PERSON_CODE == PersonCode
                                  select new PeopleViewModel { People = pl}).ToList();
            }
            return _PeopleModel;
        }
