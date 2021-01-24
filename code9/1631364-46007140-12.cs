    void OnTriggerEnter2D(Collider2D other) {
            if(other.tag == "Blue"){
                if(counterBlue == 0)
                  {  circleColour += valueBlue;}
                counterBlue++;
            }
            //Same for the other 2 colours
        }
