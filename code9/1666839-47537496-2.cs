    public class SomeViewModel : BindableBase
    {
        private readonly IPlcService _plc;
        private readonly IUnitService _unitService;
        public RealParameterVm<double> Distance { get; }
        public SomeViewModel(IPlcService plc, IUnitService unitService)
        {
            _plc = plc;
            _unitService = unitService;
            Distance = new RealParameterVm<double>(new RealParameter<double>(
                _unitService,
                _plc.Main.Interface.HmiDev.Distance,
                _plc.Main.Interface.HmiDev.DistanceCanUse,
                _plc.Main.Interface.HmiDev.DistanceIsReadOnly,
                UnitType.Distance_mm,
                PrecisionType.Position
                ), "Some distance:");
        }
    }
