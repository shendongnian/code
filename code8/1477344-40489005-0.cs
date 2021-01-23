    public class Currency
    {
       public string Name {get; set;}
       public decimal Value {get; set;}
    }
    foreach (List<Currency> item in new currencies().getAllCurr())
            {
              TextBox tbx = this.Controls.Find(item.Name, true).FirstOrDefault() as TextBox;
               tbx.text = item.Value;
            }
