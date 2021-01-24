    public class MyDateTimePicker : DateTimePicker
    {
        public MyDateTimePicker()
        {
            this.Format = DateTimePickerFormat.Custom;
            this.CustomFormat = "dd/MM/yyyy";
        }
    }
