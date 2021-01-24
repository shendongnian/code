        [JsonConstructor]
        public Truck(string manufacturer, string model, int releaseYear,
            int purchaseYear, int wheels, int miles)
        {
            if (string.IsNullOrWhiteSpace(manufacturer))
                throw new ArgumentException("Manufacture can't be empty", nameof(manufacturer));
            if (string.IsNullOrWhiteSpace(model))
                throw new ArgumentException("model can't be empty", nameof(model));
            if (releaseYear < 0 || purchaseYear < 0)
                throw new ArgumentException("Years are not negative values");
            this.Manufacturer = manufacturer;
            this.Model = model;
            this.PurchaseYear = purchaseYear;
            this.ReleaseYear = releaseYear;
            this.Wheels = wheels;
            this.Miles = miles;
        }
