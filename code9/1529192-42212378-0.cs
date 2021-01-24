            if (playerSelectedRange == true) {
                if (Input.GetKeyDown(KeyCode.UpArrow)){
                    min = guess;
                    NextGuess();
                }
                else if (Input.GetKeyDown(KeyCode.DownArrow)){
                    max = guess;
                    NextGuess();
                }
                else if (Input.GetKeyDown(KeyCode.Return)){
                    print("I won");
                    StartGame();
                }
            }else 
            {   
                if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    max = max + 100;
                    MaxRange();
                }
                else if (Input.GetKeyDown(KeyCode.DownArrow)){
                    max = max - 100;
                    MaxRange();
                }
                else if(Input.GetKeyDown(KeyCode.Return)){
                    print ("Lets play!!!");
                    print ("Choose a number between 1 and " + max);
                    max = max + 1;
                    NextGuess();
                    playerSelectedRange = true;
                }
            }
