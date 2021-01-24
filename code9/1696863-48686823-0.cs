    <Project Sdk="Microsoft.NET.Sdk.Web">
    ...
    
      <Target Name="ChangeAliasesOfStrongNameAssemblies" BeforeTargets="FindReferenceAssembliesForReferences;ResolveReferences">
        <ItemGroup>
          <ReferencePath Condition="'%(FileName)' == 'MySqlConnector'">
            <Aliases>MySqlConnectorAlias</Aliases>
          </ReferencePath>
        </ItemGroup>
      </Target>
    ...
    </Project>
