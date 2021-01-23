                        @Html.DropDownListFor(model => model.FinancialInfo.FinancialExpiryMonth, Enumerable.Range(1, 12).Select(x => new SelectListItem
               {
                   Value = x.ToString(),
                   Text = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(x),
                   Selected = (Model.FinancialInfo == null || Model.FinancialInfo.ExpiryDate == null) ? false : true
               }), "Month", new { @class = "description-text" })
 
