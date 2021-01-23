    bool awaitingPlayingPieceSelection = false;
    void Update () {
        if (chance == 1) {
            if (Input.GetKeyUp (KeyCode.Space)) {
                if (enableInput == true) {
                    enableInput = false;
                    markers [0].gameObject.SetActive (true);
                    markers [1].gameObject.SetActive (false);
                    markers [2].gameObject.SetActive (false);
                    markers [3].gameObject.SetActive (false);
                    a.PlayOneShot (s_Dice);
                    DiceRoll ();
                    if (subPlayer == 4 && diceno == 6) {
                        // ...
                    } else if (subPlayer == 3 && diceno == 6) {
                        awaitingPlayingPieceSelection = true;
                    }
                }
            }
        }
        if (awaitingPlayingPieceSelection) {
            if (Input.GetMouseButtonDown(0)) {
                // Perform your raycast in here for piece selection
                
                // Only set the variable to false once the player has selected a valid piece
                // If they click something else, keep waiting for input
                awaitingPlayingPieceSelection = false;
            }
        }
    }
