    /// <summary>
    /// A visual element that renders a box.
    /// </summary>
    /// <remarks>
    /// The box is aligned with the local X, Y and Z coordinate system
    /// Use a transform to orient the box in other directions.
    /// </remarks>
    public class TextureBoxVisual3D : ModelVisual3D
    {
        /// <summary>
        /// Identifies the <see cref="Center"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty CenterProperty = DependencyProperty.Register(
            "Center", typeof(Point3D), typeof(TextureBoxVisual3D), new UIPropertyMetadata(new Point3D(), GeometryChanged));
        /// <summary>
        /// Identifies the <see cref="Height"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty HeightProperty = DependencyProperty.Register(
            "Height", typeof(double), typeof(TextureBoxVisual3D), new UIPropertyMetadata(1.0, GeometryChanged));
        /// <summary>
        /// Identifies the <see cref="Length"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty LengthProperty = DependencyProperty.Register(
            "Length", typeof(double), typeof(TextureBoxVisual3D), new UIPropertyMetadata(1.0, GeometryChanged));
        /// <summary>
        /// Identifies the <see cref="Width"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty WidthProperty = DependencyProperty.Register(
            "Width", typeof(double), typeof(TextureBoxVisual3D), new UIPropertyMetadata(1.0, GeometryChanged));
        /// <summary>
        /// Identifies the <see cref="Source"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty SourceProperty = DependencyProperty.Register(
            "Source", typeof(string), typeof(TextureBoxVisual3D), new UIPropertyMetadata(null, GeometryChanged));
        /// <summary>
        /// The geometry changed.
        /// </summary>
        /// <param name="d">
        /// The d.
        /// </param>
        /// <param name="e">
        /// The event arguments.
        /// </param>
        private static void GeometryChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((TextureBoxVisual3D)d).UpdateModel();
        }
        /// <summary>
        /// Gets or sets the center of the box.
        /// </summary>
        /// <value>The center.</value>
        public Point3D Center
        {
            get
            {
                return (Point3D)this.GetValue(CenterProperty);
            }
            set
            {
                this.SetValue(CenterProperty, value);
            }
        }
        /// <summary>
        /// Gets or sets the height (along local z-axis).
        /// </summary>
        /// <value>The height.</value>
        public double Height
        {
            get
            {
                return (double)this.GetValue(HeightProperty);
            }
            set
            {
                this.SetValue(HeightProperty, value);
            }
        }
        /// <summary>
        /// Gets or sets the length of the box (along local x-axis).
        /// </summary>
        /// <value>The length.</value>
        public double Length
        {
            get
            {
                return (double)this.GetValue(LengthProperty);
            }
            set
            {
                this.SetValue(LengthProperty, value);
            }
        }
        /// <summary>
        /// Gets or sets the width of the box (along local y-axis).
        /// </summary>
        /// <value>The width.</value>
        public double Width
        {
            get
            {
                return (double)this.GetValue(WidthProperty);
            }
            set
            {
                this.SetValue(WidthProperty, value);
            }
        }
        /// <summary>
        /// Gets or sets the panorama/skybox directory or file prefix.
        /// </summary>
        /// <remarks>
        /// If a directory is specified, the filename prefix will be set to "cube".
        /// If the filename prefix is "cube", the faces of the cube should be named
        /// cube_f.jpg
        /// cube_b.jpg
        /// cube_l.jpg
        /// cube_r.jpg
        /// cube_u.jpg
        /// cube_d.jpg
        /// </remarks>
        /// <value>The source.</value>
        public string Source
        {
            get
            {
                return (string)this.GetValue(SourceProperty);
            }
            set
            {
                this.SetValue(SourceProperty, value);
            }
        }
        /// <summary>
        /// Do the tessellation and return the <see cref="MeshGeometry3D"/>.
        /// </summary>
        /// <returns>The mesh geometry.</returns>
        protected void UpdateModel()
        {
            if (string.IsNullOrWhiteSpace(this.Source))
            {
                return;
            }
            string directory = Path.GetDirectoryName(this.Source);
            string prefix = Path.GetFileName(this.Source);
            if (string.IsNullOrEmpty(prefix))
            {
                prefix = "cube";
            }
            var front = Path.Combine(directory, prefix + "_f.jpg");
            var left = Path.Combine(directory, prefix + "_l.jpg");
            var right = Path.Combine(directory, prefix + "_r.jpg");
            var back = Path.Combine(directory, prefix + "_b.jpg");
            var up = Path.Combine(directory, prefix + "_u.jpg");
            var down = Path.Combine(directory, prefix + "_d.jpg");
            var group = new Model3DGroup();
            group.Children.Add(this.AddCubeSide(front, new Vector3D(0, -1, 0), new Vector3D(0, 0, 1), this.Length, this.Width, this.Height));
            group.Children.Add(this.AddCubeSide(left, new Vector3D(-1, 0, 0), new Vector3D(0, 0, 1), this.Width, this.Length, this.Height));
            group.Children.Add(this.AddCubeSide(right, new Vector3D(1, 0, 0), new Vector3D(0, 0, 1), this.Width, this.Length, this.Height));
            group.Children.Add(this.AddCubeSide(back, new Vector3D(0, 1, 0), new Vector3D(0, 0, 1), this.Length, this.Width, this.Height));
            group.Children.Add(this.AddCubeSide(up, new Vector3D(0, 0, 1), new Vector3D(0, -1, 0), this.Height, this.Width, this.Length));
            group.Children.Add(this.AddCubeSide(down, new Vector3D(0, 0, -1), new Vector3D(0, 1, 0), this.Height, this.Width, this.Length));
            this.Content = group;
        }
        private static Dictionary<string, Material> _materialDict = new Dictionary<string, Material>();
        /// <summary>
        /// The add cube side.
        /// </summary>
        /// <param name="normal">
        /// The normal.
        /// </param>
        /// <param name="up">
        /// The up.
        /// </param>
        /// <param name="fileName">
        /// The file name.
        /// </param>
        /// <returns>
        /// </returns>
        private GeometryModel3D AddCubeSide(string fileName, Vector3D normal, Vector3D up, double dist, double width, double height)
        {
            string fullPath = Path.GetFullPath(fileName);
            if (!File.Exists(fullPath))
            {
                return null;
            }
            Material material = null;
            if (_materialDict.ContainsKey(fileName))
            {
                material = _materialDict[fileName];
            }
            else
            {
                var image = new BitmapImage();
                image.BeginInit();
                image.UriSource = new Uri(fullPath);
                image.EndInit();
                var brush = new ImageBrush(image);
                material = new DiffuseMaterial(brush);
                _materialDict.Add(fileName, material);
            }
            var mesh = new MeshGeometry3D();
            var right = Vector3D.CrossProduct(normal, up);
            var origin = Center;
            var n = normal * dist / 2;
            up *= height / 2;
            right *= width / 2;
            // p1 is the lower left corner
            // p2 is the upper left
            // p3 is the lower right
            // p4 is the upper right
            var p1 = origin + n - up - right;
            var p2 = origin + n + up - right;
            var p3 = origin + n - up + right;
            var p4 = origin + n + up + right;
            mesh.Positions.Add(p1);
            mesh.Positions.Add(p2);
            mesh.Positions.Add(p3);
            mesh.Positions.Add(p4);
            //doublesided
            mesh.Positions.Add(p1); // 4
            mesh.Positions.Add(p2); // 5
            mesh.Positions.Add(p3); // 6
            mesh.Positions.Add(p4); // 7
            mesh.TriangleIndices.Add(0);
            mesh.TriangleIndices.Add(3);
            mesh.TriangleIndices.Add(1);
            mesh.TriangleIndices.Add(0);
            mesh.TriangleIndices.Add(2);
            mesh.TriangleIndices.Add(3);
            //doublesided
            mesh.TriangleIndices.Add(4);
            mesh.TriangleIndices.Add(5);
            mesh.TriangleIndices.Add(7);
            mesh.TriangleIndices.Add(4);
            mesh.TriangleIndices.Add(7);
            mesh.TriangleIndices.Add(6);        
           
            mesh.TextureCoordinates.Add(new Point(0, 1));
            mesh.TextureCoordinates.Add(new Point(0, 0));
            mesh.TextureCoordinates.Add(new Point(1, 1));
            mesh.TextureCoordinates.Add(new Point(1, 0));
            //doublesided
            mesh.TextureCoordinates.Add(new Point(1, 1));
            mesh.TextureCoordinates.Add(new Point(1, 0));
            mesh.TextureCoordinates.Add(new Point(0, 1));
            mesh.TextureCoordinates.Add(new Point(0, 0));
            return new GeometryModel3D(mesh, material);
        }
    }
