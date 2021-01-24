    <ListView x:Name="listview">
        <ListView.View>
            <GridView>
                <GridViewColumn Header="Image" >
                   <GridViewColumn.CellTemplate>
                       <DataTemplate>
                           <Image Source="{Binding GuestImageProperty}" />
                       </DataTemplate>
                   </GridViewColumn.CellTemplate>
                </GridViewColumn>
                <GridViewColumn DisplayMemberBinding="{Binding Vorname}" Header="Vorname" />
                <GridViewColumn DisplayMemberBinding="{Binding Nachname}" Header="Nachname" />
                <GridViewColumn DisplayMemberBinding="{Binding Postleitzahl}" Header="PLZ" />
                <GridViewColumn DisplayMemberBinding="{Binding Ort}" Header="Ort" />
                <GridViewColumn DisplayMemberBinding="{Binding Land}" Header="Land" />
            </GridView>
        </ListView.View>
    </ListView>
