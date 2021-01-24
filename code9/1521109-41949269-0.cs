    public class StringComparisonTrigger : StateTriggerBase
    {
        private const string NotEqual = "NotEqual";
        private const string Equal = "Equal";
        public string DataValue
        {
            get { return (string)GetValue(DataValueProperty); }
            set { SetValue(DataValueProperty, value); }
        }
        public static readonly DependencyProperty DataValueProperty =
            DependencyProperty.Register(nameof(DataValue), typeof(string), typeof(StringComparisonTrigger), new PropertyMetadata(Equal, (s, e) =>
            {
                var stringComparisonTrigger = s as StringComparisonTrigger;
                TriggerStateCheck(stringComparisonTrigger, stringComparisonTrigger.TriggerValue, (string)e.NewValue);
            }));
        public string TriggerValue
        {
            get { return (string)GetValue(TriggerValueProperty); }
            set { SetValue(TriggerValueProperty, value); }
        }
        public static readonly DependencyProperty TriggerValueProperty =
            DependencyProperty.Register(nameof(TriggerValue), typeof(string), typeof(StringComparisonTrigger), new PropertyMetadata(NotEqual, (s, e) =>
            {
                var stringComparisonTrigger = s as StringComparisonTrigger;
                TriggerStateCheck(stringComparisonTrigger, stringComparisonTrigger.DataValue, (string)e.NewValue);
            }));
        private static void TriggerStateCheck(StringComparisonTrigger elementTypeTrigger, string dataValue, string triggerValue)
            => elementTypeTrigger.SetActive(dataValue == triggerValue);
    }
