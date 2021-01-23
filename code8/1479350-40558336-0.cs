    public class Person: DependencyObject
    {
        public string name
        {
            get { return (string)GetValue(nameProperty); }
            set { SetValue(nameProperty, value); }
        }
        // Using a DependencyProperty as the backing store for name.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty nameProperty =
            DependencyProperty.Register("name", typeof(string), typeof(Person), new PropertyMetadata("Fred"));
       
        public int age
        {
            get { return (int)GetValue(ageProperty); }
            set { SetValue(ageProperty, value);
                if (fireshower != null)
                    fireshower.Value = value;
            }
        }
        // Using a DependencyProperty as the backing store for age.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ageProperty =
            DependencyProperty.Register("age", typeof(int), typeof(RuleTileInfo), new PropertyMetadata(0));
    }
