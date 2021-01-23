    <View Scope="RecursiveAll">
        <Joins>
            <Join Type="INNER" ListAlias="Document Types">
                <Eq>
                    <FieldRef List="Documents" Name="Doc_x0020_Type" RefType="Id" />
                    <FieldRef List="Document Types" Name="Id" />
                </Eq>
            </Join>
        </Joins>
        <Query>
            <Where>
                <Eq>
                    <FieldRef Name="RiO_x0020_ID" />
                    <Value Type="Text">1</Value>
                </Eq>
            </Where>
        </Query>
    </View>
