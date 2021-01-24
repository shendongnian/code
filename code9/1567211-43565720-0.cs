    public partial class frmGame : Form     //Point 1
    {
        public frmGame()
        {
            InitializeComponent();
    
    
            Game.GamePlay();    //Point 2
    
        }
    
    class Game{
    
        public static void GameStart(){
            frmGame form = new frmGame();  //Point 3
        }
        public static void GamePlay()
        {
            form.lstPrevious1.Items.Add("Item Number");    
        }
    }
