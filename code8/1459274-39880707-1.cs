      <TreeView.ItemTemplate>
         <HierarchicalDataTemplate ItemsSource="{Binding Path=MenuItems}">
            <ContentControl 
                Content="{Binding Header}"
                Background="Transparent"
                >
               <ContentControl.InputBindings>
                  <MouseBinding MouseAction="LeftClick"
                                Command="{Binding Command}" />
               </ContentControl.InputBindings>
            </ContentControl>
         </HierarchicalDataTemplate>
      </TreeView.ItemTemplate>
