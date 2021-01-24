    // code behind
    DateTime date;
    TimeSpan time
    {
      get => date.TimeOfDay;
      set
      {
        date = date.AddTicks(value.Ticks);
      }
    }
    // xaml
    <DatePicker Date={x:Bind date, Converter={StaticResource DateTimeToOffsetConverter}}" 
    />
    <TimePicker Time={X:Bind time}" />
