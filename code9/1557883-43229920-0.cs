     <StackPanel DataContext="{Binding NewProductCount}" >
            <Label Content="Number of selling units:"/>
            <TextBox Text="{Binding SellingUnits, UpdateSourceTrigger=PropertyChanged}"/>
            <Label Content="Number of packing units"/>
            <TextBox Text="{Binding PackingUnits, UpdateSourceTrigger=PropertyChanged}"/>
        </StackPanel>
