    namespace WindowsFormsApp1Cs
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                MyClass c = new MyClass();
                foreach (var item in c.buttonList)
                {
                    this.Controls.Add(item.Value);
                }
            }
        }
        public class MyClass
        {
            public Dictionary<string, PictureBox> buttonList;
            public delegate void MyClickHandler(object sender, EventArgs e);
            public MyClass()
            {
                buttonList = new Dictionary<string, PictureBox>();
                buttonList.Add("button_file_1", new PictureBox() { Width = 100, Height = 100, Name = "button_file_1", Anchor = AnchorStyles.Top | AnchorStyles.Left, Top = (buttonList.Count * 100) + 10, Left = 10, ImageLocation="0.jpg" });
                buttonList.Add("button_file_2", new PictureBox() { Width = 100, Height = 100, Name = "button_file_2", Anchor = AnchorStyles.Top | AnchorStyles.Left, Top = (buttonList.Count * 100) + 10, Left = 10, ImageLocation = "0.jpg" });
                buttonList.Add("button_file_3", new PictureBox() { Width = 100, Height = 100, Name = "button_file_3", Anchor = AnchorStyles.Top | AnchorStyles.Left, Top = (buttonList.Count * 100) + 10, Left = 10, ImageLocation = "0.jpg" });
                foreach (var item in buttonList)
                {
                    bindHandler(item.Key);
                }
            }
            void bindHandler(string buttonName)
            {
                string methodName = buttonName + "_click";  
                System.Reflection.MethodInfo m = this.GetType().GetMethods().FirstOrDefault(x => x.Name == buttonName + "_click");
                PictureBox button = buttonList[buttonName];
                Delegate handler = Delegate.CreateDelegate(typeof(EventHandler), this, m);
                button.Click += (EventHandler)handler;
            }
            public void button_file_1_click(object sender, EventArgs e)
            {
                Debug.WriteLine("button_file_1_click");
            }
            public void button_file_2_click(object sender, EventArgs e)
            {
                Debug.WriteLine("button_file_2_click");
            }
            public void button_file_3_click(object sender, EventArgs e)
            {
                Debug.WriteLine("button_file_3_click");
            }
        }
    }
