    <Style TargetType="Border" BasedOn="{StaticResource keyOfYourStyle}>
   
     <Application.Resources>
        <ResourceDictionary>
        <ThisResourceWillBeAccessedEveryWhere x:Key="ResName"/>
    <ResourceDictionary.MergedDictionaries>
    				<ResourceDictionary Source="pack://application:,,,/YourAssembley;component/Resources/ButtonStyles.xaml" />
    			</ResourceDictionary.MergedDictionaries>
        </ResourceDictionary>
        </Application.Resources>
