    public class DatePickerFragment : DialogFragment, IOnDateSetListener
    {
        public static readonly string TAG = "X:" + typeof(DatePickerFragment).Name.ToUpper();
        Action<DateTime> _dateSelectedHandler = delegate { };
        public static DatePickerFragment NewInstance(Action<DateTime> onDateSelected)
        {
            var frag = new DatePickerFragment
            {
                _dateSelectedHandler = onDateSelected
            };
            return frag;
        }
        public override Dialog OnCreateDialog(Bundle savedInstanceState)
        {
            var currentDate = DateTime.Now;
            var dialog = new DatePickerDialog(Activity, this, currentDate.Year, currentDate.Month - 1, currentDate.Day);
            return dialog;
        }
        public void OnDateSet(DatePicker view, int year, int monthOfYear, int dayOfMonth)
        {
            var selectedDate = new DateTime(year, monthOfYear + 1, dayOfMonth);
            _dateSelectedHandler?.Invoke(selectedDate);
        }
    }
