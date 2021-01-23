    <CollectionViewSource x:Key="CollectionOfVideos" Source="{Binding fosaModel.ListOfVideos, UpdateSourceTrigger=PropertyChanged}" 
                                  IsLiveGroupingRequested="True" IsLiveSortingRequested="True"
                                  xmlns:s="clr-namespace:System;assembly=mscorlib">
        <CollectionViewSource.LiveGroupingProperties>
            <s:String>label</s:String>
        </CollectionViewSource.LiveGroupingProperties>
        <CollectionViewSource.GroupDescriptions>
            <PropertyGroupDescription PropertyName="label" Converter="{StaticResource LTSConverter}"/>
        </CollectionViewSource.GroupDescriptions>
    </CollectionViewSource>
