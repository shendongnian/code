    <DataGridTemplateColumn Header="TemplateColumn License">
    	<DataGridTemplateColumn.CellTemplate>
    		<DataTemplate>
    			<TextBox Text="{Binding License}">
    				<TextBox.Style>
    					<Style TargetType="{x:Type TextBox}">
    						<Style.Setters>
    							<Setter Property="Background">
    								<Setter.Value>
    									<MultiBinding Converter="{StaticResource MatchMultiCellColourConverter}">
    										<Binding Path="Text" RelativeSource="{RelativeSource Self}"/>
    										<Binding Path="user_Rank.rank"/>
    									</MultiBinding>
    								</Setter.Value>
    							</Setter>
    						</Style.Setters>
    					</Style>
    				</TextBox.Style>
    			</TextBox>
    		</DataTemplate>
    	</DataGridTemplateColumn.CellTemplate>
    </DataGridTemplateColumn>
