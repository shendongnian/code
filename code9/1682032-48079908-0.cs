        <StackPanel>
            <RadioButton x:Name="RadioButton1" GroupName="a">123</RadioButton>
            <RadioButton x:Name="RadioButton2" GroupName="a">456</RadioButton>
            <RadioButton x:Name="RadioButton3" GroupName="a">789</RadioButton>
        </StackPanel>
        
        <Button>
            <Button.Style>
                <Style TargetType="Button">
                   <Setter Property="IsEnabled" Value="False"/>
                   <Style.Triggers>
                       
                       <DataTrigger Binding="{Binding IsChecked, ElementName=RadioButton1}" Value="True">
                           <Setter Property="IsEnabled" Value="True"/>
                       </DataTrigger>
                        <DataTrigger Binding="{Binding IsChecked, ElementName=RadioButton2}" Value="True">
                            <Setter Property="IsEnabled" Value="True"/>
                        </DataTrigger>
                        <DataTrigger Binding="{Binding IsChecked, ElementName=RadioButton3}" Value="True">
                            <Setter Property="IsEnabled" Value="True"/>
                        </DataTrigger>
                    </Style.Triggers>
                </Style>
            </Button.Style>
        </Button>
