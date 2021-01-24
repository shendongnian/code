    public class Model : ReactiveObject
    {
        private ReactiveList<double> distancesBetweenXCoordinates;
        private readonly ObservableAsPropertyHelper<double> totalLength;
        public Model()
        {
            DistancesBetweenXCoordinates  = new ReactiveList<double> { ChangeTrackingEnabled = true };
            this.WhenAnyValue(x => x.DistancesBetweenXCoordinates, x => x.Sum())
                .ToProperty(this, x => x.TotalLength, out totalLength);
        }
        public ReactiveList<double> DistancesBetweenXCoordinates 
        { 
            get => distancesBetweenXCoordinates; 
            set => this.RaiseAndSetIfChanged(ref distancesBetweenXCoordinates, value); 
        } 
        public double TotalLength { get => totalLength.Value; } 
    }
