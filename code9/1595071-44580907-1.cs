	<GridView>
	    <GridViewColumn Width="90" Header="Select For Sync">
	        <GridViewColumn.CellTemplate>
	            <DataTemplate>
	                <CheckBox Tag="{Binding ID}" IsChecked="{Binding isChecked, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}"/>
	            </DataTemplate>
	        </GridViewColumn.CellTemplate>
	    </GridViewColumn>
	    <GridViewColumn Width="280" Header="Pad Name" DisplayMemberBinding="{Binding NodeName}" />
	</GridView>
