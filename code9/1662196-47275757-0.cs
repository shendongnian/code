    using System;
    using System.Globalization;
    using System.Windows.Forms;
    
    namespace YourNameSpace
    {
        public class PrimeNumberUpDown : NumericUpDown
        {
            private int _value;
    
            public PrimeNumberUpDown()
            {
                // Make sure default value is prime
                if (!IsPrime((int)Value))
                    SetNextPrimeValue();
                _value = (int)Value;
            }
    
            public override void DownButton()
            {
                SetNextPrimeValue();
            }
    
            public override void UpButton()
            {
                SetPreviousPrimeValue();
            }
    
            private void SetNextPrimeValue()
            {
                int newValue = (int)Value;
                while (newValue <= Maximum)
                {
                    if (IsPrime(++newValue))
                    {
                        if (newValue <= Maximum)
                        {
                            Value = newValue;
                            _value = newValue;
                        }
                        return;
                    }
                }
            }
    
            private void SetPreviousPrimeValue()
            {
                int newValue = (int)Value;
                while (newValue >= Minimum)
                {
                    if (IsPrime(--newValue))
                    {
                        if (newValue >= Minimum)
                        {
                            Value = newValue;
                            _value = newValue;
                        }
                        return;
                    }
                }
            }
    
            protected override void ValidateEditText()
            {
                if (_value == 0)
                {
                    base.ValidateEditText();
                    return;
                }
    
                int newValue;
                if (int.TryParse(Text, out newValue) && IsPrime(newValue) && newValue >= Minimum && newValue <= Maximum)
                {
                    _value = newValue;
                    base.ValidateEditText();
                }
                else
                {
                    ChangingText = true;
                    Text = _value.ToString(CultureInfo.InvariantCulture);
                }
            }
    
            private static bool IsPrime(int number)
            {
                if (number == 1) return false;
                if (number == 2) return true;
                if (number % 2 == 0) return false;
    
                int boundary = (int)Math.Floor(Math.Sqrt(number));
    
                for (int i = 3; i <= boundary; i += 2)
                {
                    if (number % i == 0) return false;
                }
    
                return true;
            }
        }
    }
