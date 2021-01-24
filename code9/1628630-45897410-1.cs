    public partial class Form1 : Form
        {
            Player player = new Player();
            Labyrinth labyrinth = new Labyrinth(1); // you need to default it to 1 first instead of null. because you might key press then only mouse click
    
            private void OnMouseClick(object sender, MouseEventArgs e)
            {
    	     string clicked = "1"; /// default clicked to 1
                if (window=="lvlSelect") /// if selected level is diff, then change
                     clicked = levelMenu.Click(e);
    	    labyrinth = new Labyrinth(Convert.ToInt(level)); 
            }
    
            private void OnKeyPress(object sender, KeyPressEventArgs e)
            {
                char key = e.KeyChar;
                if (window == "game")
                {player.Move(k = key.ToString(), labyrinth)}
            }
        }
