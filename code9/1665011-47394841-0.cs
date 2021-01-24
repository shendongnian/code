	public class DayOfWeekRequiredAttribute : RequiredAttribute
	{
		public override string FormatErrorMessage(string propertyName)
		{
			string day = DateTime.Today.DayOfWeek.ToString();
			return string.Format(this.ErrorMessage, propertyName, day);
		}
	}
    public partial class TaskScheduling
    {
        // {0} is property name, {1} is day of week
        [DayOfWeekRequired(ErrorMessage = "Hey, it's {1} and {0} is a required field!")]
        public string SenderName { get; set; }
    }
