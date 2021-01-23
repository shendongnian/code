    <DataTemplate DataType="{x:Type lm:Model}">
      <!-- template definition here...for example: -->
      <StackPanel>
        <TextBlock Text="{Binding Id, StringFormat=Id: {0}}"/>
      </StackPanel>
    </DataTemplate>
    <DataTemplate DataType="{x:Type lm:ModelOne}">
      <!-- template for ModelOne here; a ContentControl as shown below should be placed
           in the as needed for your desired visual appearance. For example,
           here is a template using a StackPanel as the top-level element,
           with the base class template shown as the first item in the panel -->
      <StackPanel>
        <ContentControl Content="{Binding}" Focusable="False">
          <ContentControl.ContentTemplate>
            <StaticResourceExtension>
              <StaticResourceExtension.ResourceKey>
                <DataTemplateKey DataType="{x:Type lm:Model}"/>
              </StaticResourceExtension.ResourceKey>
            </StaticResourceExtension>
          </ContentControl.ContentTemplate>
        </ContentControl>
        <TextBlock Text="{Binding Tasks, StringFormat=Tasks: {0}}"/>
      </StackPanel>
    </DataTemplate>
    <DataTemplate DataType="{x:Type lm:ModelTwo}">
      <!-- template for ModelTwo here; same as above -->
      <StackPanel>
        <ContentControl Content="{Binding}" Focusable="False">
          <ContentControl.ContentTemplate>
            <StaticResourceExtension>
              <StaticResourceExtension.ResourceKey>
                <DataTemplateKey DataType="{x:Type lm:Model}"/>
              </StaticResourceExtension.ResourceKey>
            </StaticResourceExtension>
          </ContentControl.ContentTemplate>
        </ContentControl>
        <TextBlock Text="{Binding date, StringFormat=date: {0}}"/>
      </StackPanel>
    </DataTemplate>
