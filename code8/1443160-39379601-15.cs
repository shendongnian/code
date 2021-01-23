    @model Mehvar_New.Models.QuestionnaireDetail
    <div>
        @(Html.Kendo().Grid<>(Model)
        .Name("grid")
        .Columns(columns =>
        {
        columns.Bound(c => c.QuestionText);
        columns.Bound(c => c.Value);
        columns.Command(command => {command.Destroy(); }).Width(180);
      })
      .ToolBar(toolbar => {
            toolbar.Create();
            toolbar.Save();
      }) 
      .Editable(editable => editable.Mode(GridEditMode.InCell))
      .Scrollable()
      .DataSource(dataSource => dataSource
          .Ajax()
          .Batch(true)
          .Model(model => model.Id(p => p.ID))
          .Read(read => read.Action("QuestionnaireDetail_Read", "QuestionGrid"))
          .Create(create => create.Action("QuestionnaireDetail_Create", "QuestionGrid"))
          .Update(update => update.Action("QuestionnaireDetail_Update", "QuestionGrid"))
          .Destroy(destroy => destroy.Action("QuestionnaireDetail_Destroy", "QuestionGrid"))
      )
    )
    </div>
