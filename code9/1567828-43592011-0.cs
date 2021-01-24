    void Update () {
        if (Input.GetMouseButton (0)) {
            iTween.RotateBy(gameObject, iTween.Hash("x", .25, "easeType", "easeInOutBack", "loopType", "pingPong", "delay", .4));
        }
    }
