    void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.tag == "Inner Cube")
        {
            // We have hit the inner cube
        }
        else if (other.gameObject.tag == "Outer Cube")
        {
            // We have hit the outer cube
        }
    }
