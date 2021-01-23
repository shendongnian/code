	@model Project.Model.ConversionModel
	@{
		ViewBag.Title = "Index";
	}
	@using (Html.BeginForm("Index", "Currency", FormMethod.Post)
	{
		@Html.TextBoxFor(m => m.ConversionRate, new { @size = "5" })
		@* Please check the syntax *@
		@Html.DropDownListFor(m => m.FromCurrencyId , Model.FromCurrencies as SelectList)
		@Html.DropDownListFor(m => m.ToCurrencyId , Model.ToCurrencies as SelectList)
		<button type="submit" class="btn btn-primary">Convert</button>
	}
