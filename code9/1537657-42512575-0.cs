    public class mainHub
    {
        List<List_Category> category = new List<List_Category>();
        List<Items> items = new List<Items>();
        public mainHub()
        {
            InitializeComponent();
            category.Add(new List_Category { CategoryIndex = 0, CategoryName = "Swords" }); // Add some category
            category.Add(new List_Category { CategoryIndex = 1, CategoryName = "Shields" }); // Add some category
            items.Add(new Items { CategoryIndex = 0, ItemName = "Long sword", ItemDesc = "Long sword is heavy sword with pure force"}); //Add some item to swords
            items.Add(new Items { CategoryIndex = 0, ItemName = "Short sword", ItemDesc = "Short sword is easy sword for close range fight" }); //Add some item to swords
            items.Add(new Items { CategoryIndex = 0, ItemName = "Double swords", ItemDesc = "Double swords are swords with hight mobility" }); //Add some item to swords
            items.Add(new Items { CategoryIndex = 1, ItemName = "Light shield", ItemDesc = "Light shield desc"}); //Add some item to shields
            items.Add(new Items { CategoryIndex = 1, ItemName = "Heavy shield", ItemDesc = "Heavy shield desc" }); //Add some item to shields
            
            comboBox1.DisplayMember = "CategoryName";
            comboBox1.ValueMember = "CategoryIndex";
            comboBox1.DataSource = category;
            listBox1.DisplayMember = "ItemName";
            listBox1.ValueMember = "CategoryIndex";
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedValue)
            {
                case 0:
                    var item = items.Where(category => category.CategoryIndex == 0);
                    foreach (var i in item)
                    {
                        listbox1.Items.Add(new Items { CategoryIndex = i.CategoryIndex, ItemDesc = i.ItemDesc, ItemName = i.ItemName });
                    }
                    break;
                case 1:
                    item = items.Where(category => category.CategoryIndex == 1);
                    foreach (var i in item)
                    {
                        listbox1.Items.Add(new Items { CategoryIndex = i.CategoryIndex, ItemDesc = i.ItemDesc, ItemName = i.ItemName });
                    }
                    break;
            }
        }
        private void listbox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var item = items.Where(category => category.CategoryIndex == listBox1.SelectedValue && (itemName => itemName.ItemName == listBox1.SelectedItem.ToString()));
            name_Label.Text = item.ItemName;
            description_label.Text = item.ItemDesc;
        }
    }
    public class List_Category
    {
        public int CategoryIndex { get; set; }
        public String CategoryName { get; set; }
    }
    public class Items
    {
        public int CategoryIndex { get; set; }
        public String ItemName { get; set; }
        public String ItemDesc { get; set; }
    }
