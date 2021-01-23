    public class MeasurementListController : BaseController
    {
        readonly MeasurementListService _mlS;
        public MeasurementListController(MeasurementListService mlS)
        {
            _mlS = mlS;
        }
        [HttpPost]
        public ActionResult WidgetGridGetList()
        {
            return JsonData(_mlS.GetMeasurementDataGridList());        
        }
    }
