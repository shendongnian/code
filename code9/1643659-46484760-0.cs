    public class Stock {
           public Stock(int Id,string Name,decimal Price) {
               this.Id = Id;
               this.Name = Name;
               this.Price = Price;
           }
           public int Id { get; set; }
           public string Name { get; set; }
           public decimal Price { get; set; }
    }
    List<Stock> dataSource = new List<Stock>(); // set list of object to an variable not to query db again and again, just use this all the time
    private void Form1_Load(object sender, EventArgs e) {
          dataSource = GetStocks(); 
          comboBox1.DisplayMember = "Name"; // set display member
          comboBox1.ValueMember = "Id"; // value member as Id to use at selectedIndex changed
          comboBox1.DataSource = dataSource;
    }
    public List<Stock> GetStocks() { // just creating on my own list, you won't change this
         return new List<Stock>() { new Stock(1,"test1",13) , new Stock(2, "test2", 17), new Stock(3, "test3", 113) };
    }
    
    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) {
         // query your List variable to find the stock by selected Item's Id, get first one and take Price property
          decimal value = dataSource.Where(x => x.Id == (int)comboBox1.SelectedValue).FirstOrDefault().Price; 
          textBox1.Text = value.ToString(); // set value to textbox
    }
