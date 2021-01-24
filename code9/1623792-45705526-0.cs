    <telerik:RadGridView Name="playersGrid" ItemsSource="{Binding Players}" AutoGenerateColumns="False">
      <telerik:RadGridView.SortDescriptors> <!-- define initial sorting by name-->
        <telerik:SortDescriptor Member="Name"/>  
        </telerik:RadGridView.SortDescriptors><telerik:RadGridView.Columns>
        <telerik:GridViewDataColumn DataMemberBinding="{Binding Name}"/>
        <telerik:GridViewDataColumn DataMemberBinding="{Binding Number}"/>
        <telerik:GridViewDataColumn DataMemberBinding="{Binding Position}"/>
        <telerik:GridViewDataColumn DataMemberBinding="{Binding Country}"/>
      </telerik:RadGridView.Columns>
    </telerik:RadGridView>
