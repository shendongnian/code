    public class DatePickerChangeHandler : DatePicker.IOnDateChangedListener
    {
        public IntPtr Handle
        {
            get
            {
                throw new NotImplementedException();
            }
        }
        public void Dispose()
        {
            this.Dispose();
        }
        public void OnDateChanged(DatePicker view, int year, int monthOfYear, int dayOfMonth)
        {
            ...
        }
    }
