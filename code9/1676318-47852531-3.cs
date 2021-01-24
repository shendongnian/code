    <Button Content="Normal" Command="{Binding SetViewCommand}" CommandParameter="Normal" />
    <Button Content="Edit" Command="{Binding SetViewCommand}" CommandParameter="Edit" />
    <ContentControl>
      <ContentControl.Style>
        <Style TargetType="ContentControl">
          <Style.Triggers>
            <DataTrigger Binding="{Binding ActiveView}" Value="Normal">
              <Setter Property="Content">
                <Setter.Value>
                  <UserControl1 />
                </Setter.Value>
              </Setter>
            </DataTrigger>
            <DataTrigger Binding="{Binding ActiveView}" Value="Edit">
              <Setter Property="Content">
                <Setter.Value>
                  <UserControl2 />
                </Setter.Value>
              </Setter>
            </DataTrigger>
          </Style.Triggers>
        </Style>
      </ContentControl.Style>
    </ContentControl>
