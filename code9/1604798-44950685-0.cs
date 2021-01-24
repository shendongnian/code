    public MeasDataSet(List<MeasDataPoint> path) {
       var copiedPath = new List<MeasDataPoint>();
       foreach(var point in path) {
          copiedPath.Add(new MeasDataPoint() {
             Prop1 = point.Prop1,
             Prop2 = point.Prop2
          });
       }
       // do something with your newly created deep copy of copiedPath...
    }
