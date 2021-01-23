    <ContentPresenter Content="{Binding MyValue}" 
        <ContentPresenter.Style>
             <Style TargetType="ContentPresenter">
                   <Style.Setters>
                        <Setter Property="ContentTemplate">
                               <Setter.Value>
                                    <DataTemplate>
                                         <TextBox Text="Dead beef"/>
                                    </DataTemplate>
                               </Setter.Value>
                       </Setter>
                   </Style.Setters>
             <Style.Triggers>
                   <DataTrigger Binding="{Binding Path=., Converter={StaticResource ToTypeConverter}}" Value="{x:Type mscorlib:Boolean}">
                          <Setter Property="ContentTemplate">
                                <Setter.Value>
                                      <DataTemplate>
                                           <CheckBox IsChecked="{Binding Path=.}"/>
                                      </DataTemplate>
                                </Setter.Value>
                          </Setter>
                     </DataTrigger>
               </Style.Triggers>
           </Style>
       </ContentPresenter.Style>
    </ContentPresenter>
