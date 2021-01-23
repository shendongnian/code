        using Xamarin.Forms;
        namespace testApp.Pages.Urho
        {
        public partial class urhoPage : ContentPage
        {
        Scene scene;
        Camera camera;
        protected Node CameraNode { get; set; }
        public urhoPage()
        {
            InitializeComponent();
            scene = new Scene();
            scene.CreateComponent<Octree>();
            scene.CreateComponent<DebugRenderer>();
            var planeNode = scene.CreateChild("Plane");
            planeNode.Scale = new Vector3(100f, 1f, 100f);
            var planeObject = planeNode.CreateComponent<StaticModel>();
            // Create a Zone component for ambient lighting & fog control
            var zoneNode = scene.CreateChild("Zone");
            var zone = zoneNode.CreateComponent<Zone>();
            // Set same volume as the Octree, set a close bluish fog and some ambient light
            zone.SetBoundingBox(new BoundingBox(-1000.0f, 1000.0f));
            zone.AmbientColor = new Urho.Color(0.15f, 0.15f, 0.15f);
            zone.FogColor = new Urho.Color(0.5f, 0.5f, 0.7f);
            zone.FogStart = 100f;
            zone.FogEnd = 300f;
            // Create the camera. Limit far clip distance to match the fog
            CameraNode = new Node();
	        Camera camera = CameraNode.CreateComponent<Camera>();
	        camera.FarClip = 300.0f;
            // Set an initial position for the camera scene node above the plane
            CameraNode.Position = new Vector3(0.0f, 5.0f, 0.0f);
            var renderer = Application.Current.Renderer;
	        renderer.SetViewport(0, new Viewport(Application.CurrentContext, scene, CameraNode.GetComponent<Camera>(), null));
        }
        }}
