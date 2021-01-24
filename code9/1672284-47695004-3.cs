    <Grid>
        <Grid.ColumnDefinitions>
            <ColumnDefinition Width="*"/>
            <ColumnDefinition Width="20"/>
        </Grid.ColumnDefinitions>
        <Grid.RowDefinitions>
            <RowDefinition Height="*"/>
            <RowDefinition Height="25"/>
        </Grid.RowDefinitions>
        <ScrollBar Name="vscroll" 
            Grid.Row="0" Grid.Column="1"
            Orientation="Vertical"  
            Minimum="-180" Maximum="180" 
            LargeChange="10" SmallChange="1" Value="0" />
        <ScrollBar Name="hscroll" 
            Grid.Row="1" Grid.Column="0"
            Orientation="Horizontal" 
            Minimum="-180" Maximum="180" 
            LargeChange="10" SmallChange="1" Value="0" />
        <Viewport3D Name="myViewport">
            <Viewport3D.Camera>
                <PerspectiveCamera FarPlaneDistance="10" LookDirection="-5,2,-3"
                                       UpDirection="0,1,0" NearPlaneDistance="0"
                                       Position="4.5,-1,4" FieldOfView="60">
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
            <ModelVisual3D>
                <ModelVisual3D>
                    <ModelVisual3D.Content>
                        <AmbientLight Color="#0A0000A0" />
                    </ModelVisual3D.Content>
                </ModelVisual3D>
                <ModelVisual3D>
                    <ModelVisual3D.Content>
                        <DirectionalLight Color="Red" Direction="0,0,-10" />
                    </ModelVisual3D.Content>
                </ModelVisual3D>
                <ModelVisual3D>
                    <ModelVisual3D.Content>
                        <DirectionalLight Color="Green" Direction="-5,-8,3" />
                    </ModelVisual3D.Content>
                </ModelVisual3D>
                <ModelVisual3D>
                    <ModelVisual3D.Content>
                        <DirectionalLight Color="Pink" Direction="12,4,-3" />
                    </ModelVisual3D.Content>
                </ModelVisual3D>
                <ModelVisual3D>
                    <ModelVisual3D.Content>
                        <DirectionalLight Color="Pink" Direction="4,2,4" />
                    </ModelVisual3D.Content>
                </ModelVisual3D>
                <ModelVisual3D>
                    <ModelVisual3D.Content>
                        <GeometryModel3D>
                            <GeometryModel3D.Material>
                                <DiffuseMaterial>
                                    <DiffuseMaterial.Brush>
                                        <SolidColorBrush Color="LightGray" Opacity="1.0" />
                                    </DiffuseMaterial.Brush>
                                </DiffuseMaterial>
                            </GeometryModel3D.Material>
                            <GeometryModel3D.Geometry>
                                <MeshGeometry3D
                                    Positions="
                                    0,0,0 1,0,0 2,1,0 1,2,0, 0,2,0, -1,1,0
                                    0,0,2 1,0,2 2,1,2 1,2,2, 0,2,2, -1,1,2
                                    "
                                    TriangleIndices="
                                    0,2,1 0,3,2 0,4,3 0,5,4
                                    6,7,8 6,8,9 6,9,10 6,10,11
                                    0,1,6 1,7,6
                                    1,2,7 2,8,7
                                    2,3,8 3,9,8
                                    3,4,9 4,10,9
                                    4,5,11 4,11,10
                                    5,0,6 5,6,11
                                    " />
                            </GeometryModel3D.Geometry>
                        </GeometryModel3D>
                    </ModelVisual3D.Content>
                </ModelVisual3D>
            </ModelVisual3D>
        </Viewport3D>
    </Grid>
