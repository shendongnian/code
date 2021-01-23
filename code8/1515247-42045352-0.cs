    <!-- App.csproj -->
    <Project Sdk="Microsoft.NET.Sdk">
        <PropertyGroup>
            <OutputType>Exe</OutputType>
            <TargetFramework>net461</TargetFramework>
        </PropertyGroup>
        <ItemGroup>
            <ProjectReference Include="..\Library\Library.csproj" />
        </ItemGroup>
    </Project>
    <!-- Library.csproj -->
    <Project Sdk="Microsoft.NET.Sdk">
        <PropertyGroup>
            <TargetFramework>netstandard1.1</TargetFramework>
        </PropertyGroup>
    </Project>
