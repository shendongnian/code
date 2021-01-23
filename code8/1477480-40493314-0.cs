    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            //Get Renderer or Mes Renderer
            Renderer otherRenderer = other.GetComponent<Renderer>();
            otherRenderer.sharedMaterial = material[1];
        }
    }
