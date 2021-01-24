        public double? AverageRating
        {
            get
            {
                if (Reviews == null)
                {
                    return null;
                }
                return Math.Round(Reviews.Where(x => x.Rating.HasValue).Select(x => x.Rating).DefaultIfEmpty(0).Average().Value, 1);
            }
        }
