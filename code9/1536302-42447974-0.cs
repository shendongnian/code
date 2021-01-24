    namespace WindowsFormsApplication1
                {
                    static class FormManager
                    {
                        public static Form1 Game = new Form1();
                        public static Form2 Menu = new Form2();
                    }
                    /// <summary>
                    /// The main entry point for the application.
                    /// </summary>
                    [STAThread]
                    static void Main()
                    {
                        Application.EnableVisualStyles();
                        Application.Run(FormManager.Game);
                    }
                    public partial class Form1 : Form
                    {
                        private void btn_Menu_Click(object sender, EventArgs e)
                        {
                            FormManager.Game.Hide();
                            FormManager.Menu.Show();
                        }
                    }
                    public partial class Form2 : Form
                    {
                        private void btn_Close_Click(object sender, EventArgs e)
                        {
                            FormManager.Menu.Hide();
                            FormManager.Game.Show();
                        }
                    }
                }
