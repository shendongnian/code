    public class MyButton : Button
    {
        static MyButton()
        {
            MyButton.IsEnabledProperty.OverrideMetadata(typeof(MyButton),
                new FrameworkPropertyMetadata(string.Empty,
                    FrameworkPropertyMetadataOptions.BindsTwoWayByDefault |
                    FrameworkPropertyMetadataOptions.Journal,
                    FunctionToCallOnPropertyChange, //property changed callback 
                    null, // coerce value callback 
                    true, // is animation prohibited 
                    UpdateSourceTrigger.LostFocus));
        }
        private static void FunctionToCallOnPropertyChange(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
        {
            throw new NotImplementedException();
        }
    }
