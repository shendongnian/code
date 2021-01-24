    void Update () {
        // Only bother checking for Fire3 if attacks can still be made
        if (attackNumber < 5)
        {
            if (Input.GetButtonDown ("Fire3"))
            {
                attackNumber++; // increment the counter
                meleeHitbox.gameObject.SetActive (true);
                Debug.Log ("Attack");
                // Detect when too many attacks are made only if an attack was just made
                if (attackNumber == 5) {
                    GetComponent<PlayerController>().enabled = false;
                    Debug.Log ("Too many attacks");
                }
            }
        }
        // If attacks can't be made, then check for Fire4 presses
        else
        {
            // Here should come a script that if i.e. Fire4 is pressed 10 times reset attackNumer to 0; and set PlayerController to true.
        }
        // Allow disabling of the hitbox regardless of whether attacks can be made, so it isn't left active until after the player is enabled again
        if (Input.GetButtonUp ("Fire3")) {
            meleeHitbox.gameObject.SetActive (false);
        }
    }
