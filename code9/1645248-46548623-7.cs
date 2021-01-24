    public interface IExcelCell<T> 
    {
        T Value { get; set; }
    }
    public class DateTimeExcelCell : IExcelCell<DateTime>
    {
        public DateTime Value { get; set; }
        public override string ToString()
        {
            // TODO - formatting you want for DateTime
        }
    }
