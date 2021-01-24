    internal class FuelViewModel : Screen
    {
        public FuelViewModel()
        {
            FuelType = Enum.GetValues(typeof(Fueltype)).Cast<Fueltype>().ToList();
        }
        private Fueltype selectedFuelType;
        public Fueltype SelectedFuelType
        {
            get => selectedFuelType;
            set => Set(ref selectedFuelType, value);
        }
        public IReadOnlyList<Fueltype> FuelType { get; }
    }
