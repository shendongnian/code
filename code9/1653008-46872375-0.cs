    public class ArcHydro : Oatc.OpenMI.Sdk.Backbone.LinkableComponent
    {
        public override void Initialize(IArgument[] properties)
        {
            _timeStamps = new ArrayList();
            _culture = CultureInfo.CurrentCulture.NumberFormat;
            _links = new Hashtable();
            readArcHydro();
        }
    }
