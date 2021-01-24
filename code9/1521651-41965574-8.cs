	public class MyScene
	{
		static (Scene, Node, Node, Node) f(Scene scene)
		{
			return (scene, scene.CreateChild("Camera"), scene.CreateChild("Light"), scene.CreateChild("Model"));
		}
		readonly (Scene scene, Node camera, Node light, Node model) t2 = f(new Scene());
	};
