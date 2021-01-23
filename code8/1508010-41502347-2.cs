     public void OnClickOKLevelBoard() {
            levelBoard.MoveOut (GUIAnimSystemFREE.eGUIMove.SelfAndChildren); //**Close the Board Level When OK is clicked**
            if (Player.level < 50) {
                nextLevel = Player.level + 1;
            }
            run = 1;
        }
