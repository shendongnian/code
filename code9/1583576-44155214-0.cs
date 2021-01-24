    //somewhere in your code
    Stopwatch sw = new Stopwatch();
                sw.Start();
                
    public void Draw ()
            {
                if (invisible == true) {
                    if(sw.ElapsedMilliseconds <= 3000){
    
                    SwinGame.DrawBitmap ("image2.png", (float)X, (float)Y);
    
                      } 
                }else {
                    sw.Restart();
                    SwinGame.DrawBitmap ("image1.png", (float)X, (float)Y);
                }
            }
