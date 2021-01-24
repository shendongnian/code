    public struct HddData
    {
        public Brush status { set; get; }
        public string id { set; get; }
        public string atribute { set; get; }
        public string current { set; get; }
        public string worst { set; get; }
        public string treshhold { set; get; }
        public string data { set; get; }
    }
    <DataGridTemplateColumn Header="Status">
    	<DataGridTemplateColumn.CellTemplate>
    		<DataTemplate>
    			<StackPanel>
    				<Ellipse Fill="{Binding status}" Width="10" Height="10" HorizontalAlignment="Center" VerticalAlignment="Center"/>                                
    			</StackPanel>
    		</DataTemplate>
    	</DataGridTemplateColumn.CellTemplate>
    </DataGridTemplateColumn>
    
