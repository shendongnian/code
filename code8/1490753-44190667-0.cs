    IEnumerator isPlayable(){
    		yield return new WaitForEndOfFrame();
    //		StartCoroutine(ClearConsole());
    		string debugString = "";
    		string debugLine = "En Linea: ";
    		bool playable = false;
    		// First tile to be compared
    		TileObject first = null;
    		// Next tile to be compared
    		TileObject next = null;
    		// Last tile in the 2D Array, used to determine if a loop should end or restart
    		TileObject last = null;
    		// Previous tile that was compared, saves the first tile after a next one was determined to be adjacent, this is to prevent cicled and false Trues
    		TileObject previous = null;
    		// Determines how many tiles are in line in the visible 2D Array
    		int inLine = 0;
    		foreach(GameObject GO in baseItems){
    			if(playable)
    				break;
    			debugString = debugString + GO.gameObject.GetComponent<TileObject>().name + ": \n";
    //			Debug.Log(GO.gameObject.GetComponent<TileObject>().name);
    			last = getLastInArray(GO.name);
    			previous = null;
    			first = null;
    			next = null;
    			inLine = 0;
    			for(int i = 0; i < rows; i++){
    //				Debug.Log("i: " + i);
    				for(int j = 0; j < columns; j++){
    //					Debug.Log("j: " + j);
    					if(visibleItems[i,j].name.Equals(GO.gameObject.GetComponent<TileObject>().name)){//GO.gameObject.GetComponent<TileObject>().name
    						if(first == null){
    							first = visibleItems[i,j];
    							if(inLine == 0)
    								inLine = 1;
    						} 
    						for(int a = 0; a < rows; a++){
    //							Debug.Log("a: " + a);
    							for(int b = 0; b < columns; b++){
    //								Debug.Log("b: " + b);
    								if(visibleItems[a,b].name.Equals(GO.gameObject.GetComponent<TileObject>().name)){
    									if(visibleItems[a,b].Equals(first)){
    										continue;
    									} else {
    										if(next == null){
    											next = visibleItems[a,b];
    											if(next.Equals(previous)){
    												continue;
    											} else {
    												debugString = debugString + "Es " + first.name + "(" + first.getRow() + "," + first.getColumn() + ") adyacente a ";
    												debugString = debugString + next.name + "(" + next.getRow() + "," + next.getColumn() + ")?: ";
    												if(isAdjacent(first, false, next)){
    													debugString = debugString + " Si\n";
    													previous = first;
    													first = next;
    													next = null;
    													a = i;
    													b = j;
    //													Debug.Log("Es Adyacente");
    													inLine++;
    													if(inLine >= 3){
    //														Debug.Log("Es mayor igual a 3");
    //														Debug.Log(debugString);
    														debugLine = debugLine + inLine;
    //														Debug.Log(debugLine);
    														a = rows + 1;
    														b = columns + 1;
    														i = a;
    														j = b;
    														playable = true;
    														break;
    													}
    												} else {
    //													Debug.Log("No es adyacente");
    													debugString = debugString + " No\n";
    //														Debug.Log(debugString);
    													if(next.Equals(last)){
    //														Debug.Log("Next es el ultimo");
    														previous = null;
    														first = null;
    														next = null;
    														inLine = 0;
    														break;
    	//														Debug.Log("i: " + i);
    	//														Debug.Log("j: " + j);
    													} else {
    //														Debug.Log("Next no es el ultimo");
    														next = null;
    													}
    												}
    											}
    										}
    									}
    								}
    							}
    						}
    					}
    				}
    			}
    			if(!playable){
    				debugLine = "En Linea: ";
    				debugLine = debugLine + inLine.ToString();
    //				Debug.Log(debugString);
    //				Debug.Log(debugLine);
    				debugString = "";
    				debugLine = "En Linea: ";
    			}
    //			if(playable)
    //				Debug.Log(GO.gameObject.GetComponent<TileObject>().name + " Yes"); //GO.name
    //			else
    //				Debug.Log(GO.gameObject.GetComponent<TileObject>().name + " No"); //GO.name
    		}
    		if(!playable){
    //			Debug.Log("No es Jugable");
    			allowGame = false;
    		} else {
    //			Debug.Log("Es jugable");
    			allowGame = true;
    		}
    
    		if(allowGame){
    			if(!CandyCrushMain.Script.getStart()){
    				CandyCrushMain.Script.gameStart();
    				CandyCrushMain.Script.setEndTime();
    			}
    		}
    	}
