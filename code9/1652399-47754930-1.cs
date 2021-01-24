    <configSections>
    <section name="unity" type="Microsoft.Practices.Unity.Configuration.UnityConfigurationSection, Unity.Configuration"/>
    </configSections>
    <unity xmlns="http://schemas.microsoft.com/practices/2010/unity">
     <container>
       <register type="FileBox.IStorageSystem, FileBox" mapTo="FileBox.StorageSystem.Local.LocalFileSystem, FileBox" >
        <constructor>
          <param name="root">
            <value value =""/>
          </param>
        </constructor>
      </register>
     </container>
