    void OnCollisionEnter(Collision col) {
        if (col.gameObject.name == "Player") {
            if (Materialstate == 0) {
                renderComp.material = goal;
                Materialstate = 1;
                return;
            }
            renderComp.material = starting;
            Materialstate = 0;
        }
    }
    
