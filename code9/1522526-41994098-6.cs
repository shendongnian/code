    @model EmployeeSkillVM
    ...
	@using (Html.BeginForm())
	{
        ....
        @Html.HiddenFor(m => m.ID)
        ....
		<table>
			<thead>
				<tr>
					<th></th>
					@foreach(var skill in Model.SkillList)
					{
						<th>@skill</th>
					}
				</tr>
			</thead>
			<tbody>
				@for(int i = 0; i < Model.Employees.Count; i++)
				{
					<tr>
						<td>
							@Html.HiddenFor(m => m.Employees[i].ID)
							@Html.HiddenFor(m => m.Employees[i].Name)
							@Html.DisplayFor(m => m.Employees[i].Name)
						</td>
						@for(int j = 0; j < Model.Employees[i].Skills.Count; j++)
						{
						 	<td>
								@Html.HiddenFor(m => Model.Employees[i].Skills[j].ID)
								@Html.CheckBoxFor(m => Model.Employees[i].Skills[j].IsSelected)
							</td>
						}
					</tr>
				}
			</tbody>
		</table>
		<input type="submit" value="Save" />
	}
