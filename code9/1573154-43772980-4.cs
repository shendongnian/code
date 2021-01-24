    <Window x:Class="WpfApplication15.MainWindow"
            xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
            xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
            Title="MainWindow" Height="350" Width="525">
        <Grid>
            <DockPanel Margin="0" Name="dockOuter" Background="White">
                <Button DockPanel.Dock="Top" Click="Button_Click">Load</Button>
                <DockPanel Margin="0" Name="dockCue" Background="White">
                    <ScrollBar Name="hscroll" 
          DockPanel.Dock="Bottom"
          Orientation="Horizontal" 
          Minimum="-360" Maximum="360" 
          LargeChange="10" SmallChange="1" Value="0" />
                    <ScrollBar Name="vscroll" 
          DockPanel.Dock="Right"
          Orientation="Vertical"
          Minimum="-360" Maximum="360" 
          LargeChange="10" SmallChange="1" Value="0" />
                    <Viewport3D Margin="0" Name="viewCube">
                        <ModelVisual3D>
                            <ModelVisual3D.Content>
                                <Model3DGroup x:Name="group">
                                    <!--Ligthts-->
                                    <AmbientLight Color="Yellow" />
                                    <DirectionalLight Color="gray" Direction="1,-2,-3" />
                                    <DirectionalLight Color="Gray" Direction="-1,2,3" />
                                    <!-- 1-top -->
                                    <GeometryModel3D>
                                        <GeometryModel3D.Geometry>
                                            <MeshGeometry3D
                                                Positions = "-1,1,1 1,1,1 1,1,-1 -1,1,-1"
    	                                        TriangleIndices = "0,1,2 2,3,0"
                                                TextureCoordinates="0,1 1,1 1,0 0,0"
                                            />
                                        </GeometryModel3D.Geometry>
                                        <GeometryModel3D.Material>
                                            <DiffuseMaterial>
                                                <DiffuseMaterial.Brush>
                                                    <ImageBrush ImageSource="s:\1.jpg"/>
                                                </DiffuseMaterial.Brush>
                                            </DiffuseMaterial>
                                        </GeometryModel3D.Material>
                                    </GeometryModel3D>
    
                                    <!-- 2-front -->
                                    <GeometryModel3D>
                                        <GeometryModel3D.Geometry>
                                            <MeshGeometry3D
                                                Positions = "-1,-1,1 1,-1,1 1,1,1 -1,1,1"
    	                                        TriangleIndices = "0,1,2 2,3,0"
                                                TextureCoordinates="0,1 1,1 1,0 0,0"
                                            />
                                        </GeometryModel3D.Geometry>
                                        <GeometryModel3D.Material>
                                            <DiffuseMaterial>
                                                <DiffuseMaterial.Brush>
                                                    <ImageBrush ImageSource="s:\2.jpg"/>
                                                </DiffuseMaterial.Brush>
                                            </DiffuseMaterial>
                                        </GeometryModel3D.Material>
                                    </GeometryModel3D>
    
                                    <!-- 3-right -->
                                    <GeometryModel3D>
                                        <GeometryModel3D.Geometry>
                                            <MeshGeometry3D
                                                Positions = "1,-1,1 1,-1,-1 1,1,-1 1,1,1"
    	                                        TriangleIndices = "0,1,2 2,3,0"
                                                TextureCoordinates="0,1 1,1 1,0 0,0"
                                            />
                                        </GeometryModel3D.Geometry>
                                        <GeometryModel3D.Material>
                                            <DiffuseMaterial>
                                                <DiffuseMaterial.Brush>
                                                    <ImageBrush ImageSource="s:\3.jpg"/>
                                                </DiffuseMaterial.Brush>
                                            </DiffuseMaterial>
                                        </GeometryModel3D.Material>
                                    </GeometryModel3D>
    
                                    <!-- 4-left -->
                                    <GeometryModel3D>
                                        <GeometryModel3D.Geometry>
                                            <MeshGeometry3D
                                                Positions = "-1,-1,-1 -1,-1,1 -1,1,1 -1,1,-1"
    	                                        TriangleIndices = "0,1,2 2,3,0"
                                                TextureCoordinates="0,1 1,1 1,0 0,0"
                                            />
                                        </GeometryModel3D.Geometry>
                                        <GeometryModel3D.Material>
                                            <DiffuseMaterial>
                                                <DiffuseMaterial.Brush>
                                                    <ImageBrush ImageSource="s:\4.jpg"/>
                                                </DiffuseMaterial.Brush>
                                            </DiffuseMaterial>
                                        </GeometryModel3D.Material>
                                    </GeometryModel3D>
    
                                    <!-- 5-back -->
                                    <GeometryModel3D>
                                        <GeometryModel3D.Geometry>
                                            <MeshGeometry3D
                                                Positions = "1,-1,-1 -1,-1,-1 -1,1,-1 1,1,-1"
    	                                        TriangleIndices = "0,1,2 2,3,0"
                                                TextureCoordinates="0,1 1,1 1,0 0,0"
                                            />
                                        </GeometryModel3D.Geometry>
                                        <GeometryModel3D.Material>
                                            <DiffuseMaterial>
                                                <DiffuseMaterial.Brush>
                                                    <ImageBrush ImageSource="s:\5.jpg"/>
                                                </DiffuseMaterial.Brush>
                                            </DiffuseMaterial>
                                        </GeometryModel3D.Material>
                                    </GeometryModel3D>
    
                                    <!-- 6-bottom -->
                                    <GeometryModel3D>
                                        <GeometryModel3D.Geometry>
                                            <MeshGeometry3D
                                                Positions = "-1,-1,-1 1,-1,-1 1,-1,1 -1,-1,1"
    	                                        TriangleIndices = "0,1,2 2,3,0"
                                                TextureCoordinates="0,1 1,1 1,0 0,0"
                                            />
                                        </GeometryModel3D.Geometry>
                                        <GeometryModel3D.Material>
                                            <DiffuseMaterial>
                                                <DiffuseMaterial.Brush>
                                                    <ImageBrush ImageSource="s:\6.jpg"/>
                                                </DiffuseMaterial.Brush>
                                            </DiffuseMaterial>
                                        </GeometryModel3D.Material>
                                    </GeometryModel3D>
    
                                </Model3DGroup>
    
                            </ModelVisual3D.Content>
                        </ModelVisual3D>
    
                        <Viewport3D.Camera>
    
                            <PerspectiveCamera
                          Position = "5, 5, 5"
                          LookDirection = "-5, -5, -5"
                          UpDirection = "0, 1, 0"
                          FieldOfView = "60">
    
                                <PerspectiveCamera.Transform>
                                    <Transform3DGroup>
                                        <RotateTransform3D>
                                            <RotateTransform3D.Rotation>
                                                <AxisAngleRotation3D
                                              Axis="0 1 0" 
                                              Angle="{Binding ElementName=hscroll, Path=Value}" />
                                            </RotateTransform3D.Rotation>
                                        </RotateTransform3D>
                                        <RotateTransform3D>
                                            <RotateTransform3D.Rotation>
                                                <AxisAngleRotation3D
                                              Axis="1 0 0" 
                                              Angle="{Binding ElementName=vscroll, Path=Value}" />
                                            </RotateTransform3D.Rotation>
                                        </RotateTransform3D>
                                    </Transform3DGroup>
                                </PerspectiveCamera.Transform>
    
                            </PerspectiveCamera>
                        </Viewport3D.Camera>
                    </Viewport3D>
                </DockPanel>
            </DockPanel>
        </Grid>
    </Window>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
            }
    
            private void buildCube()
            {
                group.Children.Clear(); // clear out the existing geometry XAML
    
                // Lights
    
                group.Children.Add(new AmbientLight(Colors.Gray));
                group.Children.Add(new DirectionalLight(Colors.Gray, new Vector3D(1, -2, -3)));
                group.Children.Add(new DirectionalLight(Colors.Gray, new Vector3D(-1, 2, 3)));
    
                // Top
                {
                    MeshGeometry3D mesh = new MeshGeometry3D();
                    mesh.Positions.Add(new Point3D(-1, 1, 1));
                    mesh.Positions.Add(new Point3D(1, 1, 1));
                    mesh.Positions.Add(new Point3D(1, 1, -1));
                    mesh.Positions.Add(new Point3D(-1, 1, -1));
                    mesh.TriangleIndices.Add(0);
                    mesh.TriangleIndices.Add(1);
                    mesh.TriangleIndices.Add(2);
                    mesh.TriangleIndices.Add(2);
                    mesh.TriangleIndices.Add(3);
                    mesh.TriangleIndices.Add(0);
                    mesh.TextureCoordinates.Add(new Point(0, 1));
                    mesh.TextureCoordinates.Add(new Point(1, 1));
                    mesh.TextureCoordinates.Add(new Point(1, 0));
                    mesh.TextureCoordinates.Add(new Point(0, 0));
                    BitmapImage bitmapimage = new BitmapImage(new Uri(@"S:\1.jpg"));
                    Brush brush = new ImageBrush(bitmapimage);
                    GeometryModel3D geommodel3d = new GeometryModel3D(mesh, new DiffuseMaterial(brush));
                    group.Children.Add(geommodel3d);
                }
    
                // Front
                {
                    MeshGeometry3D mesh = new MeshGeometry3D();
                    mesh.Positions.Add(new Point3D(-1, -1, 1));
                    mesh.Positions.Add(new Point3D(1, -1, 1));
                    mesh.Positions.Add(new Point3D(1, 1, 1));
                    mesh.Positions.Add(new Point3D(-1, 1, 1));
                    mesh.TriangleIndices.Add(0);
                    mesh.TriangleIndices.Add(1);
                    mesh.TriangleIndices.Add(2);
                    mesh.TriangleIndices.Add(2);
                    mesh.TriangleIndices.Add(3);
                    mesh.TriangleIndices.Add(0);
                    mesh.TextureCoordinates.Add(new Point(0, 1));
                    mesh.TextureCoordinates.Add(new Point(1, 1));
                    mesh.TextureCoordinates.Add(new Point(1, 0));
                    mesh.TextureCoordinates.Add(new Point(0, 0));
                    BitmapImage bitmapimage = new BitmapImage(new Uri(@"S:\2.jpg"));
                    Brush brush = new ImageBrush(bitmapimage);
                    GeometryModel3D geommodel3d = new GeometryModel3D(mesh, new DiffuseMaterial(brush));
                    group.Children.Add(geommodel3d);
                }
    
                // Right
                {
                    MeshGeometry3D mesh = new MeshGeometry3D();
                    mesh.Positions.Add(new Point3D(1, -1, 1));
                    mesh.Positions.Add(new Point3D(1, -1, -1));
                    mesh.Positions.Add(new Point3D(1, 1, -1));
                    mesh.Positions.Add(new Point3D(1, 1, 1));
                    mesh.TriangleIndices.Add(0);
                    mesh.TriangleIndices.Add(1);
                    mesh.TriangleIndices.Add(2);
                    mesh.TriangleIndices.Add(2);
                    mesh.TriangleIndices.Add(3);
                    mesh.TriangleIndices.Add(0);
                    mesh.TextureCoordinates.Add(new Point(0, 1));
                    mesh.TextureCoordinates.Add(new Point(1, 1));
                    mesh.TextureCoordinates.Add(new Point(1, 0));
                    mesh.TextureCoordinates.Add(new Point(0, 0));
                    BitmapImage bitmapimage = new BitmapImage(new Uri(@"S:\3.jpg"));
                    Brush brush = new ImageBrush(bitmapimage);
                    GeometryModel3D geommodel3d = new GeometryModel3D(mesh, new DiffuseMaterial(brush));
                    group.Children.Add(geommodel3d);
                }
    
                // Left
                {
                    MeshGeometry3D mesh = new MeshGeometry3D();
                    mesh.Positions.Add(new Point3D(-1, -1, -1));
                    mesh.Positions.Add(new Point3D(-1, -1, 1));
                    mesh.Positions.Add(new Point3D(-1, 1, 1));
                    mesh.Positions.Add(new Point3D(-1, 1, -1));
                    mesh.TriangleIndices.Add(0);
                    mesh.TriangleIndices.Add(1);
                    mesh.TriangleIndices.Add(2);
                    mesh.TriangleIndices.Add(2);
                    mesh.TriangleIndices.Add(3);
                    mesh.TriangleIndices.Add(0);
                    mesh.TextureCoordinates.Add(new Point(0, 1));
                    mesh.TextureCoordinates.Add(new Point(1, 1));
                    mesh.TextureCoordinates.Add(new Point(1, 0));
                    mesh.TextureCoordinates.Add(new Point(0, 0));
                    BitmapImage bitmapimage = new BitmapImage(new Uri(@"S:\4.jpg"));
                    Brush brush = new ImageBrush(bitmapimage);
                    GeometryModel3D geommodel3d = new GeometryModel3D(mesh, new DiffuseMaterial(brush));
                    group.Children.Add(geommodel3d);
                }
    
                // Back
                {
                    MeshGeometry3D mesh = new MeshGeometry3D();
                    mesh.Positions.Add(new Point3D(1, -1, -1));
                    mesh.Positions.Add(new Point3D(-1, -1, -1));
                    mesh.Positions.Add(new Point3D(-1, 1, -1));
                    mesh.Positions.Add(new Point3D(1, 1, -1));
                    mesh.TriangleIndices.Add(0);
                    mesh.TriangleIndices.Add(1);
                    mesh.TriangleIndices.Add(2);
                    mesh.TriangleIndices.Add(2);
                    mesh.TriangleIndices.Add(3);
                    mesh.TriangleIndices.Add(0);
                    mesh.TextureCoordinates.Add(new Point(0, 1));
                    mesh.TextureCoordinates.Add(new Point(1, 1));
                    mesh.TextureCoordinates.Add(new Point(1, 0));
                    mesh.TextureCoordinates.Add(new Point(0, 0));
                    BitmapImage bitmapimage = new BitmapImage(new Uri(@"S:\5.jpg"));
                    Brush brush = new ImageBrush(bitmapimage);
                    GeometryModel3D geommodel3d = new GeometryModel3D(mesh, new DiffuseMaterial(brush));
                    group.Children.Add(geommodel3d);
                }
    
                // Bottom
                {
                    MeshGeometry3D mesh = new MeshGeometry3D();
                    mesh.Positions.Add(new Point3D(-1, -1, -1));
                    mesh.Positions.Add(new Point3D(1, -1, -1));
                    mesh.Positions.Add(new Point3D(1, -1, 1));
                    mesh.Positions.Add(new Point3D(-1, -1, 1));
                    mesh.TriangleIndices.Add(0);
                    mesh.TriangleIndices.Add(1);
                    mesh.TriangleIndices.Add(2);
                    mesh.TriangleIndices.Add(2);
                    mesh.TriangleIndices.Add(3);
                    mesh.TriangleIndices.Add(0);
                    mesh.TextureCoordinates.Add(new Point(0, 1));
                    mesh.TextureCoordinates.Add(new Point(1, 1));
                    mesh.TextureCoordinates.Add(new Point(1, 0));
                    mesh.TextureCoordinates.Add(new Point(0, 0));
                    BitmapImage bitmapimage = new BitmapImage(new Uri(@"S:\6.jpg"));
                    Brush brush = new ImageBrush(bitmapimage);
                    GeometryModel3D geommodel3d = new GeometryModel3D(mesh, new DiffuseMaterial(brush));
                    group.Children.Add(geommodel3d);
                }
            }
    
            private void Button_Click(object sender, RoutedEventArgs e)
            {
                buildCube();
            }
        }
    }
