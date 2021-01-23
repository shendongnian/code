    public class MeasurementListService
    {
        readonly MeasurementListRepository _mlR;
        public MeasurementListService(MeasurementListRepository mlR)
        {
            _mlR = mlR;
        }
        public virtual IList<Location> GetMeasurementDataGridList()
        {
            return _mlR.GetLocations();
        }
    }
