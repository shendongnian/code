            <Image Source = "{Binding Img}" Stretch="Fill">
                <Image.InputBindings>
                    <MouseBinding MouseAction="LeftDoubleClick" Command="{Binding DoubleClickCommand}" />
                    <MouseBinding MouseAction="LeftClick" Command="{Binding MouseUpCommand}" />
                </Image.InputBindings>
            </Image>
