    void OnTriggerEnter(Collider col) {
        // if you don't want more than 1 dps instance on an object, otherwise remove if
        if (col.GetComponent<MyDpsAbility>() == null) {
            var dps = col.AddComponent<MyDpsAbility>();
            dps.Damage = 10f;
            dps.ApplyEveryNSeconds(1);
            // and set the rest of the public variables
        }
    }
