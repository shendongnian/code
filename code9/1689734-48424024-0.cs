    public class KerningLabel : Label
    {
        public static readonly BindableProperty KerningProperty = BindableProperty.Create(nameof(Kerning), typeof(double), typeof(KerningLabel), 0d);
    
        public double Kerning
        {
            get { return (double)GetValue(KerningProperty); }
            set { SetValue(KerningProperty, value); }
        }
    }
