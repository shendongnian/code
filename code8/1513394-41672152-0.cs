    <ContentPresenter Content="{Binding YouTypeHere}">
                 <ContentPresenter.Resources>
                     <DataTemplate DataType="{x:Type fristViewModel1Type}">
                         <youControlForViewModel1 />
                     </DataTemplate>
                     <DataTemplate DataType="{x:Type secondViewModel2Type}">
                         <youControlForViewModel2 />
                     </DataTemplate>
                </ContentPresenter.Resources>
             </ContentPresenter>
