    public class NumericValidationTriggerAction : TriggerAction<Entry>
    {
        protected override void Invoke(Entry entry)
        {
            double result;
            bool isValid = Double.TryParse(entry.Text, out result);
            entry.BackgroundColor =
                  isValid ? Color.Default : Color.Red;
        }
    }
    EventTrigger ETrigger = new EventTrigger
    {
        Event = "TextChanged"
    };
    ETrigger.Actions.Add(new NumericValidationTriggerAction());
    entry.Triggers.Add(ETrigger);
