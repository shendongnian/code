    @for (int i = 0; i < Model.ProfessionalRelations.Count; i++)
    {
        @Html.RadioButtonFor(m => m.SelectedProfessionalRelation, 
             Model.ProfessionalRelations[i].Text) 
        Model.ProfessionalRelations[i].Text
    }
