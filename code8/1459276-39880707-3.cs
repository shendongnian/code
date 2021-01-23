      <TreeView.ItemTemplate>
         <HierarchicalDataTemplate ItemsSource="{Binding Path=MenuItems}">
            <ContentControl 
                Content="{Binding Header}"
                Background="Transparent"
                >
               <ContentControl.InputBindings>
                  <!-- This invokes the command, but breaks selection -->
                  <MouseBinding MouseAction="LeftClick"
                                Command="{Binding Command}" />
               </ContentControl.InputBindings>
            </ContentControl>
         </HierarchicalDataTemplate>
      </TreeView.ItemTemplate>
