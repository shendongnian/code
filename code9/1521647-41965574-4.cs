	sealed class MyScene2
	{
		public Scene scene => new Scene();
		public Node camera => scene.CreateChild("Camera");
		public Node light => scene.CreateChild("Light");
		public Node model => scene.CreateChild("Model");
	}
