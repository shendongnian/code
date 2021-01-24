	public class MyScene
	{
		static (Scene, Node, Node, Node) f()
		{
			var scene = new Scene();
			return (scene, scene.CreateChild("Camera"), scene.CreateChild("Light"), scene.CreateChild("Model"));
		}
		(Scene scene, Node camera, Node light, Node model) t => f();
	}
