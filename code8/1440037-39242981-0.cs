    <GridViewColumn>
        <GridViewColumn.DisplayMemberBinding>
            <PriorityBinding>
               <Binding Path="Exception" Mode="OneWay" Converter="{StaticResource typeConverter}" IsAsync="True" />
               <Binding Path="AnotherProperty" IsAsync="True" />
            </PriorityBinding>
        </GridViewColumn.DisplayMemberBinding>
    </GridViewColumn>
