    <ListView>
        <ListView.View>
            <GridView>
                <GridViewColumn DisplayMemberBinding="{Binding FirstProperty}">
                    <GridViewColumn.Header>
                        <GridViewColumnHeader>FirstPropertyName</GridViewColumnHeader>
                    </GridViewColumn.Header>
                 </GridViewColumn>
                 <GridViewColumn DisplayMemberBinding="{Binding SecondProperty}">
                    <GridViewColumn.Header>
                        <GridViewColumnHeader>SecondPropertyName</GridViewColumnHeader>
                    </GridViewColumn.Header>
                </GridViewColumn>
            </GridView>
        </ListView.View>
    </ListView>
