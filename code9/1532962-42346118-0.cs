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
                _enemy.OnLoopInteration += enemy_onLoopInteration;
                _enemy.MyMethod();
                _enemy.OnLoopInteration -= enemy_onLoopInteration;
            }
    
            private void enemy_onLoopInteration(object sender, LoopCounterArgs e)
            {
                textBox1.Text = Convert.ToString(e.Iteration);
            }
        }
    }
