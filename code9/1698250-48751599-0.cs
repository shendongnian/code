    @model DemoMvc.Models.EmployeeViewModel
    @using (Html.BeginForm())
    {
        <div>
            <table id="dimensionFeedbackTable">
                <tbody>
                    @for (int i = 0; i <  Model.DepartmentViewModels.Count; i++){
                        <tr>
                            <td>
                                <div>
                                    <p>
                                        <text>
                                            Rate @Model.DepartmentViewModels[i].DepartmentCode
                                        </text>
                                    </p>
                                </div>
                            </td>
                            @for (int j = 1; j <= 6; j++)
                            {
                                <td>
                                    <div style="text-align: center;">
                                        @Html.RadioButtonFor(m => 
                                            Model.DepartmentViewModels[i].DepartmentValue, 
                                            j, new { style = "min-height:45px;" }) 
                                        @j
                                    </div>
                                </td>
                            }
                        </tr>
                    }
                </tbody>
            </table>
            <button id="submitComment" value="submit">Submit</button>
        </div>
    }
