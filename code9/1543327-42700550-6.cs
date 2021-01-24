    <Application x:Class="MecamApplication.Client.App" 
             ...
             xmlns:Converters="clr-namespace:MecamApplication.Core.Converters;assembly=MecamApplication.Core">
    <Application.Resources>
        <ResourceDictionary>
            <Converters:ScreenSizeConverter x:Key="ScreenSizeConverter"/>
        </ResourceDictionary>
    </Application.Resources>
