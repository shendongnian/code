    public class CompanyBuildingObject
    {
        private int _CompanyId = 0;
        private int _BuildingId = 0;
        private int _BuildingUnitId = 0;
        public int Company_Id
        {
            get { return _CompanyId; }
            set { _CompanyId = value; }
        }
        public int Building_Id
        {
            get { return _BuildingId; }
            set { _BuildingId = value; }
        }
        public int BuildingUnit_Id
        {
            get { return _BuildingUnitId; }
            set { _BuildingUnitId = value; }
        }
        public CompanyBuildingObject()
        {
            Company_Id = 0;
            Building_Id = 0;
            BuildingUnit_Id = 0;
        }
    }
        [HttpPut]
        [ResponseType(typeof(CompanyBuildingUnit))]
        [Route("api/CompanyBuildingUnits/PutCompanyBuildingUnit/{id}")]
        public IHttpActionResult PutCompanyBuildingUnit(int id, CompanyBuildingObject cbo)
        {
            return Ok(SyncCompanyBuildingUnits(id, cbo));
        }
        [HttpPost]
        [ResponseType(typeof(CompanyBuildingUnit))]
        [Route("api/CompanyBuildingUnits/PostCompanyBuildingUnit/")]
        public IHttpActionResult PostCompanyBuildingUnit(CompanyBuildingObject cbo)
        {
            return Ok(SyncCompanyBuildingUnits(0, cbo));
        }
