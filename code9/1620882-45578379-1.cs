    void Update() {
        if (Input.GetKeyDown(KeyCode.R)) // Note no ; here!
        {
            GetComponent<Renderer>().material.color = Color.red;
        }
    }
    public void Method1() {
        // Some code
    }
