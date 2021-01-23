    using System.Reflection;
    using System.Resources;
    
    ResourceManager resources = new ResourceManager("Namespace.ResourceFile", Assembly.GetExecutingAssembly());
    Bitmap bitmap = (Bitmap) resources.GetObject("Image"); //image without extension
	myButton.BackgroundImage = bitmap;
