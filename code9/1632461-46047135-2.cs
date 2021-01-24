    void OnCollisionEnter(Collision col) {
        if (col.gameObject.name == "Player") {
            switch (Materialstate)
            {
                case 0:
                    renderComp.material = goal;
                    Materialstate = 1;
                    break;
                case 1:
                    renderComp.material = starting;
                    Materialstate = 0;
                    break;
                default: 
                    // Invalid Materialstate throw exception/error
            }
        }
    }
