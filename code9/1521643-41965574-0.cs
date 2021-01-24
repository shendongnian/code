	static class ChildCreator
	{
		public static (Scene scene, Node camera, Node light, Node model) Create(string camera, string light, string model)
		{
			var scene = new Scene();
			var c = scene.CreateChild(camera);
			var l = scene.CreateChild(light);
			var m = scene.CreateChild(model);
			return (scene, c, l, m);
		}
	}
	public class MyScene
	{
		ValueTuple<Scene, Node, Node, Node> vt = ChildCreator.Create("Camera", "Light", "Model");
	}
