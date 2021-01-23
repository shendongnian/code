    <Project ToolsVersion="4.0" xmlns="http://schemas.microsoft.com/developer/msbuild/2003">
      <PropertyGroup>
        <WebPublishMethod>Package</WebPublishMethod>
        <LastUsedBuildConfiguration>Release</LastUsedBuildConfiguration>
        <LastUsedPlatform>Any CPU</LastUsedPlatform>
        <SiteUrlToLaunchAfterPublish />
        <LaunchSiteAfterPublish>True</LaunchSiteAfterPublish>
        <ExcludeApp_Data>False</ExcludeApp_Data>
        <DesktopBuildPackageLocation>obj\Release\Package\package.zip</DesktopBuildPackageLocation>
        <PackageAsSingleFile>true</PackageAsSingleFile>
        <DeployIisAppPath />
        <PublishDatabaseSettings>
          <Objects xmlns="">
           ...
          </Objects>
        </PublishDatabaseSettings>
      </PropertyGroup>
      <ItemGroup>
        <MSDeployParameterValue Include="$(DeployParameterPrefix)DefaultConnection-Web.config Connection String" />
      </ItemGroup>
    </Project>
