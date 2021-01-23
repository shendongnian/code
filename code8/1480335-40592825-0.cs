    public class MyNullableTextBox : TextBox
    {
        public bool IsEmpty {get{return String.IsNullOrEmpty(base.Text);} }
        public decimal Value
        {
           get
           {
               if (this.IsEmpty)
                   return 0M;
               else
               {
                   decimal parsedValue;
                   bool parsed = Decimal.TryParse(base.Text, out parsedValue);
                   if (!parsed)
                       // decide what you want in this case
                   else
                       return parsedValue;
                }
            }
        }
    }
