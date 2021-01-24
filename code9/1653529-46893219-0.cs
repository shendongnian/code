    @{ 
         string ToDisplay = item.MinimumOnHandQuantity.ToString();
         if (item.UseForecast)
         {
               ToDisplay += "*";
         }
    }
    @Html.Raw(ToDisplay) 
