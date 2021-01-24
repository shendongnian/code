    //Get maximum X and Y Pos
    int maxXPos = pbCanvas.Size.Width / Settings.Width;
    int maxYPos = pbCanvas.Size.Height / Settings.Height;
    
    //Detect collission with game borders.
    if (Snake[i].X < 0 ){
        Snake[i].X = maxXPos;
    }
	else if(Snake[i].Y < 0){
		Snake[i].Y = maxYPos;
	}
	else if(Snake[i].X >= maxXPos){
		Snake[i].X = 0;
	}
	else if(Snake[i].Y >= maxYPos){
		Snake[i].Y = 0;
	}
