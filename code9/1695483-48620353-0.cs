    public partial class Form1 : Form
    {
     public Form1()
     {
        InitializeComponent();
        var weekends = GetDaysBetween(DateTime.Today.AddMonths(-1), DateTime.Today.AddMonths(12))
    .Where(d => d.DayOfWeek == DayOfWeek.Saturday || d.DayOfWeek == DayOfWeek.Sunday).ToArray();
        monthCalendar1.RemoveAllBoldedDates();
        monthCalendar1.BoldedDates = weekends;
     }
    IEnumerable<DateTime> GetDaysBetween(DateTime start, DateTime end)
     {
        for (DateTime i = start; i <= end; i = i.AddDays(1))
        {
            yield return i;
        }
     }
    }
