    <ScrollView>
        <dxGrid:GridControl 
            x:Name="grid" 
            ItemsSource="{Binding materials}"
            AutoFilterPanelVisibility="true"
            IsReadOnly="true"
            SortMode="Multiple"
            SelectedRowHandle="{Binding selectedRow, Mode=TwoWay}"
            SelectedDataObject="{Binding selectedRowObject, Mode=TwoWay}">
            <dxGrid:GridControl.Columns>
                <dxGrid:TextColumn 
                    FieldName="description" 
                    Caption = "Material" 
                    AutoFilterCondition="Contains"/>
                </dxGrid:GridControl.Columns>
            </dxGrid:GridControl>
        </ScrollView>
    public int selectedRow
        {
            set
            {
                if(SelectedRow != value)
                {
                    SelectedRow = value;
                    if(PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("selectedRow"));
                    }
                }
            }
            get
            {
                return SelectedRow;
            }
        }
        public Object selectedRowObject
        {
            set
            {
                if (SelectedRowObject != value)
                {
                    SelectedRowObject = value;
                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("selectedRowObject"));
                        PropertyChanged(this, new PropertyChangedEventArgs("selectedRowDescription"));
                    }
                }
            }
            get
            {
                return SelectedRowObject;
            }
        }
        public String selectedRowDescription
        {
            get
            {
                if(SelectedRowObject != null && SelectedRowObject is Material)
                {
                    Material mat = (Material)SelectedRowObject;
                    return mat.description;
                } else
                {
                    return "-";
                }
            }
        }
