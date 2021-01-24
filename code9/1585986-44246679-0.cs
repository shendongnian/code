    void Start()
    {
        StartCoroutine( GameLogic() ) ;
    }
    
    IEnumerator GameLogic () {
    
        while (true )
        {
            if (chosen == false) {
                if (choice != "")
                    chosen = true;
            }
    
            if (chosen == true){
                enemyChoice = "";
                int n = rnd.Next(num.Count);
                enemyChoice = choices [n];
                Debug.Log (choice); // Here choice should be printed, then the coroutine started and then enemy choice printed
                
                Debug.Log ("Before Wait");
                yield return new WaitForSeconds (2);
                Debug.Log ("After Wait");
                
                Debug.Log (enemyChoice);
                chosen = false;
                toDecide = true;
            }
    
    
            if (toDecide == true){ // sorry for the clunky way of deciding the result
                if (choice == enemyChoice) {
                    Debug.Log ("Draw");
                } else if (choice == "rock" && enemyChoice == "paper") {
                    Debug.Log ("Lose");
                } else if (choice == "rock" && enemyChoice == "scissors") {
                    Debug.Log ("Win");
                } else if (choice == "paper" && enemyChoice == "rock") {
                    Debug.Log ("Win");
                } else if (choice == "paper" && enemyChoice == "scissors") {
                    Debug.Log ("Lose");
                } else if (choice == "scissors" && enemyChoice == "paper") {
                    Debug.Log ("Win");
                } else if (choice == "scissors" && enemyChoice == "rock") {
                    Debug.Log ("Lose");
                } else {
                    Debug.Log ("Error");
                }
    
                toDecide = false;
                choice = "";
                enemyChoice = "";
            }
            
            yield return null ; // To wait one frame
        }
    }
