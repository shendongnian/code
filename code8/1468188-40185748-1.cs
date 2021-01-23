    bool c_pressed = false;
    void state_Cell () {
            if (c_pressed || Input.GetKeyDown (KeyCode.C)) {            
               c_pressed = true;
                if (Input.GetKeyDown (KeyCode.B)) {
                   c_pressed = false;
                    MyState = States.Bed;
                }
            }
            else
                 c_pressed = false;
        }
    }
