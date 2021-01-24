     <ItemGroup>
        <Content Include="..\..\Payloads\**\*.*">
          <Link>Payloads\%(RecursiveDir)%(FileName)%(Extension)</Link>
          <CopyToOutputDirectory>None</CopyToOutputDirectory>
          <CopyToPublishDirectory>PreserveNewest</CopyToPublishDirectory>
        </Content>
      </ItemGroup>
