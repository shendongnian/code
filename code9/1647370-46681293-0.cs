    public class MonthYearPickerDialog : DialogFragment
    {
        private const int MAX_YEAR = 2099;
        private DatePickerDialog.IOnDateSetListener listener;
        public void setListener(DatePickerDialog.IOnDateSetListener listener)
        {
            this.listener = listener;
        }
        public override Dialog OnCreateDialog(Bundle savedInstanceState)
        {
            AlertDialog.Builder builder = new AlertDialog.Builder(Activity);
            // Get the layout inflater
            LayoutInflater inflater = Activity.LayoutInflater;
            Calendar cal = Calendar.Instance;
            View dialog = inflater.Inflate(Resource.Layout.date_picker_dialog, null);
            NumberPicker monthPicker = (NumberPicker)dialog.FindViewById(Resource.Id.picker_month);
            NumberPicker yearPicker = (NumberPicker)dialog.FindViewById(Resource.Id.picker_year);
            monthPicker.MinValue = 1;
            monthPicker.MaxValue = 12;
            monthPicker.Value = cal.Get(CalendarField.Month) + 1;
            int year = cal.Get(CalendarField.Year);
            yearPicker.MinValue = year;
            yearPicker.MaxValue = MAX_YEAR;
            yearPicker.Value = year;
            builder.SetView(dialog)
                .SetPositiveButton("Ok", (sender,e)=> 
                {
                    listener.OnDateSet(null, yearPicker.Value, monthPicker.Value, 0);
                })
                .SetNegativeButton("Cancel", (sender, e) =>
                {
                    this.Dialog.Cancel();
                });
            return builder.Create();
        }
    }
