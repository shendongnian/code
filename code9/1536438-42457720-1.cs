        using HelixToolkit.Wpf;
    using System;
    using System.Windows;
    using System.Windows.Media;
    using System.Windows.Media.Animation;
    using System.Windows.Media.Media3D;
    using System.Windows.Shapes;
    
    namespace test_storyboard_02
    {
        public partial class MainWindow : Window
        {
            public Storyboard myStoryboard = new Storyboard();
            public Model3DGroup MainModel3Dgroup = new Model3DGroup();
    
            Model3DGroup modelFloor;
            public MainWindow()
            {
                InitializeComponent();
            }
    
            private void Window_Loaded(object sender, RoutedEventArgs e)
            {
                LoadObj();
                view1.ZoomExtents();
                NameScope scope = new NameScope();
                FrameworkContentElement element = new FrameworkContentElement();
                NameScope.SetNameScope(element, scope);
    
                // Create a box  that will be the target
                // of the animation.
                // Material material = HelixToolkit.Wpf.MaterialHelper.CreateMaterial(Colors.DarkBlue);
                // MeshBuilder meshBuilder = new MeshBuilder();
                // meshBuilder.AddBox(new Point3D(0, 0, 0), 200, 200, 200);
                // GeometryModel3D modelFloor = new GeometryModel3D(meshBuilder.ToMesh(), material);
                // modelFloor.SetName("floor");
                // MainModel3Dgroup.Children.Add(modelFloor);
    
                var lights = new DefaultLights();
                view1.Children.Add(lights);
    
                ModelVisual3D model_visual = new ModelVisual3D();
                model_visual.Content = modelFloor; 
                view1.Children.Add(model_visual);
                view1.ZoomExtents();
    
                AxisAngleRotation3D rotation = new AxisAngleRotation3D(new Vector3D(0, 0, 1), 0);
                RotateTransform3D myRotateTransform3D = new RotateTransform3D(rotation, new Point3D(0, 0, 0));
    
                modelFloor.Transform = myRotateTransform3D;
    
                element.RegisterName("rotation", rotation);
    
                // Create two DoubleAnimations and set their properties.
                DoubleAnimation animation = new DoubleAnimation();
                animation.From = 0;
                animation.To = 200;
                animation.Duration = TimeSpan.FromSeconds(2);
    
                Storyboard.SetTargetProperty(animation, new PropertyPath("Angle"));
                Storyboard.SetTargetName(animation, "rotation");
                myStoryboard.Children.Add(animation);
                myStoryboard.Duration = TimeSpan.FromSeconds(2);
    
                // Make the Storyboard a resource.
                this.Resources.Add("unique_id1", myStoryboard);
                myStoryboard.Begin(element, HandoffBehavior.Compose);
    
            }
            private void LoadObj()
            {
                view1.Children.Clear();
                modelFloor = new Model3DGroup();
                ModelImporter importer = new ModelImporter();
                Model3D ModelCube = importer.Load(@"e:\x.obj");
                modelFloor.Children.Add(ModelCube);
                view1.Children.Add(new ModelVisual3D { Content = modelFloor });
            }
        }
    }
