    readonly MeasurementListService _mlS;
    
    public MeasurementListController()
    {
         _mlS = /* some default value */;
    }
    
    public MeasurementListController(MeasurementListService mlS)
    {
       _mlS = mlS;
    }
