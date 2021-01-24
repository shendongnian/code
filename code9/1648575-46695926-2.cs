    public class ClassicMovieAttribute : ValidationAttribute
    {
        private int _year;
        public ClassicMovieAttribute(int Year)
        {
            _year = Year;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            Movie movie = (Movie)validationContext.ObjectInstance;
            if (movie.Genre == Genre.Classic && movie.ReleaseDate.Year > _year)
            {
                return new ValidationResult(GetErrorMessage());
            }
            return ValidationResult.Success;
        }
    }
