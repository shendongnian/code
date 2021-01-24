    void C()
            {
                ModelVisual3D model = new ModelVisual3D();
    
                model.Content = Display3d(@"D:\tests for projects\Em organic compounds\Em organic compounds\Car.3DS");
    
                RotateManipulator manipulator = new RotateManipulator()
                {
                    //rotate on X axis
                    Axis = new Vector3D(1, 0, 0),
                    Diameter = 5 //
                };
                Binding b = new Binding()
                {
                    ElementName = nameof(model),
                    Path = new PropertyPath("Transform")
                };
                BindingOperations.SetBinding(manipulator, RotateManipulator.TransformProperty, b);
                BindingOperations.SetBinding(manipulator, RotateManipulator.TargetTransformProperty, b);
    
                view1.Children.Add(manipulator);
    
                view1.Children.Add(model);
    
            }
            private Model3D Display3d(string mdl)
            {
                Model3D device = null;
                try
                {
    
                    // view1.RotateGesture = new MouseGesture(MouseAction.LeftClick);
                    ModelImporter import = new ModelImporter();
    
    
                    device = import.Load(mdl);
                }
                catch (Exception e)
                {
                    MessageBox.Show("Exception Error : " + e.StackTrace);
                }
                return device;
            }
