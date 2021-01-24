    <Button Name="btnCashDenomination" CommandParameter="{Binding     CashDenominationObj,Mode=TwoWay,UpdateSourceTrigger=PropertyChanged}" Tag="{Binding}" Command="{Binding CashDenominationCommand}"  Width="35" Height="35" Style="{DynamicResource MetroCircleButtonStyle}" ToolTip="Add Denomination"  >
         <Image Width="30" Source="/Images/icons/add.png"  Margin="0,1,0,0"></Image>
         <Button.Resources>
              <Style TargetType="Button">
                   <Style.Triggers>
                        <DataTrigger Binding="{Binding IsEnable,Mode=TwoWay,UpdateSourceTrigger=PropertyChanged}" Value="true">
                             Setter Property="Visibility" Value="Visible"></Setter>
                         </DataTrigger>
                         <DataTrigger Binding="{Binding IsEnable,Mode=TwoWay,UpdateSourceTrigger=PropertyChanged}" Value="false">
                             <Setter Property="Visibility" Value="Collapsed"></Setter>
                         </DataTrigger>
                    </Style.Triggers>
                </Style>
           </Button.Resources>
      </Button>
