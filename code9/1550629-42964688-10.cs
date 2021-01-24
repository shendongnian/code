    void OnCollisionEnter(Collision bol)
    {
        MeshRenderer ballMesh = bol.gameObject.GetComponent<MeshRenderer>();
    
        if (ColourDistance((Color32)ballMesh.sharedMaterial.color, (Color32)Color.red) < 300)
        {
            lives = lives - 1;
            Debug.Log("Collided red");
        }
        else if (ColourDistance((Color32)ballMesh.sharedMaterial.color, (Color32)Color.green) < 300)
        {
            lives = lives - 2;
            Debug.Log("Collided green");
        }
    
        else if (ColourDistance((Color32)ballMesh.sharedMaterial.color, (Color32)Color.black) < 300)
        {
            lives = lives - 3;
            Debug.Log("Collided black");
        }
    }
    
