    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            //Get Renderer or Mesh Renderer
            Renderer otherRenderer = other.GetComponent<Renderer>();
            otherRenderer.sharedMaterial = material[1];
        }
    }
