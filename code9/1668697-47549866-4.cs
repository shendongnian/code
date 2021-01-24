    <ListView ItemsSouce="{Binding Bestellungen}">
    <ListView.View>
          <GridView>
               <GridViewColumn Header="Id" DisplayMemberBinding="{Binding Id}"/>
               <GridViewColumn Header="Artikelnr" DisplayMemberBinding="{Binding Artikelnr}"/>
               <GridViewColumn Header="Bezeichnung" DisplayMemberBinding="{Binding Bezeichnung}"/>
               <GridViewColumn Header="Menge">
                   <GridViewColumn.CellTemplate>
                         <DataTemplate>
                              <TextBox Width="80" Text="{Binding Menge}"/>
                         </DataTemplate>
                   </GridViewColumn.CellTemplate>
               </GridViewColumn>    
           </GridView>
      </ListView.View>
