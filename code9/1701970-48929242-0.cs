    namespace DatabaseTest
    {
        public class FocusedTriggerAction : TriggerAction<Entry>
        {
            protected override void Invoke(Entry entry)
            {
                MessagingCenter.Send<FocusedTriggerAction>(this, "changeList");
            }
        }
    }
