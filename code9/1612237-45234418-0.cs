    <Window x:Class="PrismUnityApp1TestValidation.Views.MainWindow"
            xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
            xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
            xmlns:prism="http://prismlibrary.com/"
            prism:ViewModelLocator.AutoWireViewModel="True"
            Title="{Binding Title}" Height="350" Width="525">
        <StackPanel>
            <!--<ContentControl prism:RegionManager.RegionName="ContentRegion" />-->
            <TabControl>
            <TabItem IsSelected="{Binding TabItem1Selected}">
             <TabItem.Content>
                 <AdornerDecorator>
                     <TextBox Height="50" Text="{Binding TestText, ValidatesOnDataErrors=True, NotifyOnValidationError=True, UpdateSourceTrigger=PropertyChanged, Mode=TwoWay}"></TextBox>
                        </AdornerDecorator>
                            
             </TabItem.Content>
            </TabItem>
                <TabItem>
                    <TabItem.Content>
                       <TextBlock Text="TabItem2"></TextBlock>
                    </TabItem.Content>
                </TabItem>
    
            </TabControl>
        </StackPanel>
    </Window>
