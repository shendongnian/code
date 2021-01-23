    @foreach(var item in Model)
    {
        <div>
            <span>@item.MemberName</span>
            <span>@item.TransactId</span>
            <span>@Html.DisplayFor(m => item.PayDate)</span>
        </div>
        foreach(var payment in item.Payments)
        {
            <div>
                <span>@payment.Category</span>
                <span>@Html.DisplayFor(m => payment.Amount)</span>
            </div>
        }
        <div>
            <span>Total</span>
            <span>@Html.DisplayFor(m => item.TotalAmount)</span>
        <div>
    }
