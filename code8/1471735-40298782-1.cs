    <ContentControl Content="{Binding }">
    	<ContentControl.Style>
    		<Style>
    			<Style.Triggers>
    				<DataTrigger Binding="{Binding Path=IsStudent}" Value="True">
    					<Setter Property="ContentControl.ContentTemplate" Value="{StaticResource grdStudentView}" />
    				</DataTrigger>
    				<DataTrigger Binding="{Binding Path=IsAcademic}" Value="True">
    					<Setter Property="ContentControl.ContentTemplate" Value="{StaticResource grdAcademicView}" />
    				</DataTrigger>
    			</Style.Triggers>
    		</Style>
    	</ContentControl.Style>
    </ContentControl>
