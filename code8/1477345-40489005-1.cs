    public class Currency
    {
       public string Name {get; set;}
       public decimal Value {get; set;}
    }
    foreach (List<Currency> item in new currencies().getAllCurr())
            {
              Label tbx = this.Controls.Find(item.Name, true).FirstOrDefault() as Label;
               tbx.text = item.Value;
            }
