       <TreeView ItemsSource="{Binding TreeViewItems}">
          <TreeView.ItemTemplate>
             <HierarchicalDataTemplate ItemsSource="{Binding Path=MenuItems}">
                <ContentPresenter Content="{Binding Header}">
                   <i:Interaction.Triggers>
                      <i:EventTrigger EventName="MouseLeftButtonUp">
                         <i:InvokeCommandAction Command="{Binding Path=DataContext.Command, RelativeSource={RelativeSource FindAncestor, AncestorType={x:Type TreeViewItem}}}" />
                      </i:EventTrigger>
                   </i:Interaction.Triggers>
                </ContentPresenter>
             </HierarchicalDataTemplate>
          </TreeView.ItemTemplate>
       </TreeView>
