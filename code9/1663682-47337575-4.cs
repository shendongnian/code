    class YearData 
    {
        List<int, int> _data = new List<int, int>();
        public int GetYearData(int year)
        {
            AssertYearValid(year);
            return _data[year];
        }
        public void SetYearData(int year, int number)
        {
            AssertYearValid(year);
            AssertYearNumberValid(number);
            _data[year] = number;
        }
        private void AssertYearValid(int year)
        {
            if (year < 1900 || year > 2900)
            {
                throw new ArgumentException("Year is not valid.");
            }
        }
    }
    public class SummaryDto
    {
        public string Name {get; set;};
        public string GenericName {get; set; }
        public YearData Data {get; } = new YearData();
    }
