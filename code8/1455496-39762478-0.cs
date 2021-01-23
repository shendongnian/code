    <GridView x:Name="gridView" IsItemClickEnabled="True" ItemClick="gridView_ItemClick">
        <GridView.ItemTemplate>
            <DataTemplate>
                <Grid>
                    <Grid.Resources>
                        <Storyboard x:Name="std" x:Key="std">
                            <DoubleAnimation Storyboard.TargetName="rtt" Storyboard.TargetProperty="Angle"
                             Duration="0:0:3" From="0" To="360" />
                        </Storyboard>
                    </Grid.Resources>
                    <Image Source="{Binding ImageAddress}" Width="200" Height="200">
                        <Image.RenderTransform>
                            <RotateTransform x:Name="rtt" CenterX="100" CenterY="100" />
                        </Image.RenderTransform>
                    </Image>
                </Grid>
            </DataTemplate>
        </GridView.ItemTemplate>
    </GridView>
