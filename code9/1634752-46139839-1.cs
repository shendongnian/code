    public class Panels
    {
         public Panel[6,6] Panels;
         int xcoordinate;
         int ycoordinate;
         public Panel CurrentPanel{get{return Panels[xcoordinate,ycoordinate];}
         public void MoveUp()
         {
             BeforeMove();
             if(ycoordinate>0) ycoordinate--;
             OnMove();
         }
         //declare MoveDown, MoveLeft and MoveRight similiarly
         ...
         private void BeforeMove()
         {
             CurrentPanel.BackColor=Color.White;
         }
         private void OnMove()
         {
            CurrentPanel.BackColor=Color.Black;
         }
    }
