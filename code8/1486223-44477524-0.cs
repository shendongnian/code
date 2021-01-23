    zone.FogStart = 300.0f;
	zone.FogEnd = 500.0f;
    CameraNode = new Node();
	Camera camera = CameraNode.CreateComponent<Camera>();
	camera.FarClip = 300.0f;
	// Set an initial position for the camera scene node above the floor
	CameraNode.Position = (new Vector3(0.0f, 5.0f, 0.0f));
    var renderer = Application.Current.Renderer;
	renderer.SetViewport(0, new Viewport(Application.CurrentContext, scene, CameraNode.GetComponent<Camera>(), null));
		
