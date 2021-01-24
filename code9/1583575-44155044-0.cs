    <telerik:GridViewColumn Header="Date of Travel *">
        <telerik:GridViewColumn.CellTemplate>
            <DataTemplate>
                <TextBlock Text="{Binding Path=FlightDate, Mode=OneWay, StringFormat=dd-MMM-yyyy}" />
            </DataTemplate>
        </telerik:GridViewColumn.CellTemplate>
        <telerik:GridViewColumn.CellEditTemplate>
            <DataTemplate>
                <telerik:RadDatePicker SelectedDate="{Binding Path=FlightDate, Mode=TwoWay, StringFormat=dd-MMM-yyyy, UpdateSourceTrigger=LostFocus}" DisplayFormat="Short" Culture="en-AU" />
            </DataTemplate>
        </telerik:GridViewColumn.CellEditTemplate>
    </telerik:GridViewColumn>
