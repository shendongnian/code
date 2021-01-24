    public partial class Form1 : Form
        {
            Player player = new Player();
            Labyrinth labyrinth;
    
            private void OnMouseClick(object sender, MouseEventArgs e)
            {
                if (window=="lvlSelect")
                    string clicked = levelMenu.Click(e);
    
                switch (clicked)
                {
                    case "1":
                      level = 1; 
                       labyrinth = new Labyrinth(level);
                      break;
                    case "2":
                      level = 2; 
                       labyrinth = new Labyrinth(level);
                      break;
                    case "3":
                      level = 3; 
                      labyrinth = new Labyrinth(level);
                      break;
                }           
            }
    
            private void OnKeyPress(object sender, KeyPressEventArgs e)
            {
                char key = e.KeyChar;
                if (window == "game")
                {player.Move(k = key.ToString(), labyrinth)}
            }
        }
