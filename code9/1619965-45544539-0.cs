    <DataGridComboBoxColumn Header="Status"
                            SelectedValueBinding="{Binding Status}"
                            SelectedValuePath="Tag"
                            xmlns:s="clr-namespace:System;assembly=mscorlib">
        <DataGridComboBoxColumn.ItemsSource>
            <x:Array Type="{x:Type Image}">
                <Image Source="1.png">
                    <Image.Tag>
                        <s:Int32>1</s:Int32>
                    </Image.Tag>
                </Image>
                <Image Source="2.png">
                    <Image.Tag>
                        <s:Int32>2</s:Int32>
                    </Image.Tag>
                </Image>
            </x:Array>
        </DataGridComboBoxColumn.ItemsSource>
    </DataGridComboBoxColumn>
