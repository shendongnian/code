        public double? AverageRating
        {
            get
            {
                if (Reviews == null)
                {
                    return null;
                }
                return Math.Round(Reviews.Where(x => x.Rating.HasValue).Average(x => x.Rating.Value), 1);
            }
        }
