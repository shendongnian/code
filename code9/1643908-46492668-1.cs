    public sealed class MyTextBox : TextBox
    {
        public MyTextBox()
        {
            this.DefaultStyleKey = typeof(TextBox);
        }
        public CaseType CharacterCasing
        {
            get { return (CaseType)GetValue(CharacterCasingProperty); }
            set { SetValue(CharacterCasingProperty, value); }
        }
        public static readonly DependencyProperty CharacterCasingProperty = DependencyProperty.Register("CharacterCasing", typeof(CaseType), typeof(MyTextBox), new PropertyMetadata(CaseType.Normal,(s,e)=>
        {
            TextBox myTextBox = (TextBox)s;
            if ((CaseType)e.NewValue !=(CaseType)e.OldValue)
            {
                myTextBox.TextChanged += MyTextBox_TextChanged;
            }
            else
            {
                myTextBox.TextChanged -= MyTextBox_TextChanged;
            }
        }));
        private static void MyTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            MyTextBox myTextBox = sender as MyTextBox;
            switch(myTextBox.CharacterCasing)
            {
                case CaseType.UpperCase:
                    myTextBox.Text = myTextBox.Text.ToUpper();
                    break;
                case CaseType.LowerCase:
                    myTextBox.Text = myTextBox.Text.ToLower();
                    break;
                default:
                    break;
            }
            myTextBox.SelectionStart = myTextBox.Text.Length;
        }
        public enum CaseType
        {
            Normal,
            UpperCase,
            LowerCase
        }
    }
