    <Project Sdk="Microsoft.NET.Sdk.Web">
    
      <PropertyGroup>
        <TargetFramework>netcoreapp2.0</TargetFramework>
      </PropertyGroup>
      <ItemGroup>
        <Content Update="wwwroot\html-templates\**\*.*">
          <CopyToOutputDirectory>Always</CopyToOutputDirectory>
        </Content>
      </ItemGroup>
    </Project>
