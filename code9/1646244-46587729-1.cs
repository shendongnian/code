    public Cylinder()
    {
        GameObject cylinder = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        var shrink = cylinder.AddComponent<ShrinkBehaviour>();
        shrink.StartShrink(new ShrinkBehaviour.Config() { startSize = Vector3.one * 10, destinationSize = Vector3.one * 1, speed = 0.2f });
        cylinder.transform.position = new Vector3(3, 0, 0);
        cylinder.GetComponent<MeshRenderer>().material.color = Random.ColorHSV();
        Destroy(cylinder, 30.0f);
    }
