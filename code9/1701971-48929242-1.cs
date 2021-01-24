    namespace DatabaseTest
    {
        public class FocusedTriggerAction : TriggerAction<Picker>
        {
            protected override void Invoke(Picker sender)
            {
                MessagingCenter.Send<FocusedTriggerAction>(this, "changeList");
            }
        }
    }
