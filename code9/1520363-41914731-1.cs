    public class SoonDueReportsController_simple : BaseODataController
    {
        public SoonDueReportsController_simple(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }
    
        [Queryable(AllowedQueryOptions = AllowedQueryOptions.All)]
        public IQueryable<SomeModel> Get()
        {
            var falligkeiten = UnitOfWork.GetAll<Fälligkeiten>();
            var betriebe = UnitOfWork.GetAll<Betriebe>();
    
            var query = (from betrieb in betriebe.AsQueryable()
                        join fallig in falligkeiten.AsQueryable()
                        on betrieb.ID equals
                        fallig.Betrieb_ID
                        where fallig.Fälligkeit_Erledigt_Datum == null
                        && betrieb.Aktiv == true
                        select new SomeModel
                        {
                            BetriebId = betrieb.ID,
                            FalligkeitObject = fallig.Fälligkeit_Objekt
                        });
            return query;
        }
    }
    
    public class SomeModel 
    {
        public int BetriebId { get; set; }
        public string FalligkeitObject { get; set; }
    }
