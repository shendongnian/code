     public class WebSyncDetailEntity
    {
        public Web_SyncMatchesEntity WebSyncMatch { get; set; }
        public Web_LookupsEntity WebLookups { get; set; }
        public PeopleEntity People { get; set; }
    }
...
     private List<WebSyncDetailEntity> ProcessGetWebSyncDetail()
        {
            List<WebSyncDetailEntity> WebSyncDetailObject = null;
            using (var _uow = new UCAS_WebSync_AdminTool_UOF())
            {
                try
                {
                    List<PeopleEntity> peopleEntity = null ;
                    int? personCode = _uow.Web_SyncMatchesRepository.GetAll().Where(x => x.SUBMISSION_ID == "28105").Select(y => y.PERSON_CODE).FirstOrDefault() ;
                    using(var _fes_uow = new FES_UOF())
                    {
                        peopleEntity = _fes_uow.PeopleRepository.GetAll().Where(x => x.PERSON_CODE == personCode).ToList();
                    }
                    WebSyncDetailObject = (from esm in _uow.Web_SyncMatchesRepository.GetAll()
                                             join lup in (_uow.Web_LookupsRepository.GetAll().Where(a => a.RV_DOMAIN == "match_method")) on esm.MATCH_METHOD equals lup.LOOKUP_KEY
                                             where esm.SUBMISSION_ID == "28105"
                                             select new WebSyncDetailEntity { WebSyncMatch = esm, WebLookups = lup }).ToList();
                      int index = 0;
                      foreach(var item in WebSyncDetailObject)
                      {
                          WebSyncDetailObject[index].People = peopleEntity.Where(x => x.PERSON_CODE == WebSyncDetailObject[index].WebSyncMatch.PERSON_CODE).FirstOrDefault();
                          index++;
                      }
                }
                catch(Exception exp)
                {
                    Debug.WriteLine(exp.ToString());
                }
            }
                return null;
        }
