    <RadioButton Checked="Radiobutton_OnChecked" Content="E">
          <RadioButton.Resources>
              <Style TargetType="{x:Type RadioButton}">
                   <Style.Triggers>
                         <Trigger Property="IsChecked" Value="True">
                              <Setter Property="Background" Value="{DynamicResource MaterialDesignSelection}" />
                         </Trigger>
                   </Style.Triggers>
              </Style>
          </RadioButton.Resources>
     </RadioButton>
