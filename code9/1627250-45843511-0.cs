    you can polymorphically draw the without checking the type.
    
     public class View
       {
          public void Draw(IDrawing drawing)
          {
             drawing.Draw();
          }
       }
    Encapsulate each drawing strategy (Strategy Pattern) in different class and you could inject each strategy via DI.
