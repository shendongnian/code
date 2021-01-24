    namespace WindowsFormsApplication2 {
    
    public partial class Form1 : Form
    
        {
            public Form1()
            {
                InitializeComponent();
                /*_enemy = new Class1(this);
                int y = Class1.MyMethod(0);
                textBox1.Text = Convert.ToString (y);*/
            }
            private Class1 _enemy;
    
            private void button1_Click(object sender, EventArgs e)
            {
                _enemy = new Class1(this);
                _enemy.LoopInteration += OnLoopInteration;
                _enemy.MyMethod();
                _enemy.LoopInteration -= OnLoopInteration;
            }
    
            private void OnLoopInteration(object sender, LoopCounterArgs e)
            {
                textBox1.Text = Convert.ToString(e.Iteration);
            }
        }
    }
