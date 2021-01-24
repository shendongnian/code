        public double? AverageRating
        {
            get
            {
                if (Reviews == null)
                {
                    return null;
                }
                return Math.Round(Reviews.Where(x => x.Rating.HasValue).DefaultIfEmpty(0).Average(x => x.Rating.Value), 1);
            }
        }
