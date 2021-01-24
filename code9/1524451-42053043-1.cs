    namespace WindowsFormsApplication1
    {
        public class CustomListItem
        {
            public string Text { get; set; }
            public int EnumValue { get; set; }
    
        }
    }
    
    public enum NamesA { Adam = 0, Albert = 1 };
    public enum NamesB { Bert = 2, Bob = 3 }
        public partial class Form1 : Form
        {
           
            public Form1()
            {
                InitializeComponent();
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                List <CustomListItem> nameList = new List<CustomListItem>();
                            int reason = 1;
            if (reason == 1)
                foreach (NamesA item in Enum.GetValues(typeof(NamesA)))
                    nameList.Add(new CustomListItem { Text = item.ToString(), EnumValue = (int)item });
            else if (reason == 2)
            {
                foreach (NamesB item in Enum.GetValues(typeof(NamesB)))
                    nameList.Add(new CustomListItem { Text = item.ToString(), EnumValue = (int)item });
            }
            else
            {
                foreach (NamesA item in Enum.GetValues(typeof(NamesA)))
                    nameList.Add(new CustomListItem { Text = item.ToString(), EnumValue = (int)item });
                foreach (NamesB item in Enum.GetValues(typeof(NamesB)))
                    nameList.Add(new CustomListItem { Text = item.ToString(), EnumValue = (int)item });
            }
            listBox1.DataSource = nameList;
            listBox1.DisplayMember = "Text";
            listBox1.ValueMember = "EnumValue";
               
            }
    
            private void button_Click(object sender, EventArgs e)
            {
                int chosenNameEnumValue = (int) listBox1.SelectedValue;
    
                switch (chosenNameEnumValue)
                {
                    case (int) NamesA.Adam:
                        /*some stuff happens*/
                        break;
                    case (int) NamesA.Albert:
                        /*other stuff happens*/
                        break;
                    case (int)NamesB.Bert:
                        /*some stuff happens*/
                        break;
                    case (int)NamesB.Bob:
                        /*other stuff happens*/
                        break;
                    default:
                        /* ...and so on */
                        break;
                }
            }
    }
