     <Image Source="ms-appx:///Assets/Progress.png" Width="{Binding ImageWidth}" Height="{Binding ImageHeight}" >
                    <Image.Clip>
                        <RectangleGeometry Rect="{Binding Rect}" >
                            <RectangleGeometry.Transform>
                                <RotateTransform CenterX="{Binding CenterXY}" CenterY="{Binding CenterXY}" Angle="{Binding Angle}" />
                            </RectangleGeometry.Transform>
                        </RectangleGeometry>
                    </Image.Clip>
                </Image>
