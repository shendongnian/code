        public double? AverageRating
        {
            get
            {
                if (Reviews == null)
                {
                    return null;
                }
                return Math.Round(Reviews.Select(x => x.Rating).DefaultIfEmpty(0).Average(), 1);
            }
        }
