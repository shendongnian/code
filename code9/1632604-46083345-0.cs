    GameObject NewCube(Vector3 pos, Vector3 scale, Color color) {
        GameObject cubePrototype = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cubePrototype.transform.position = pos;
        cubePrototype.transform.localScale = scale;
        
        Material materialPrototype = new Material(Shader.Find("Unlit/Color"));
        materialPrototype.color = color;
        Renderer cubeRenderer = new Renderer(cubePrototype.GetComponent<Renderer>());
        cubeRenderer.material = materialPrototype;
        return cubePrototype;
    }
