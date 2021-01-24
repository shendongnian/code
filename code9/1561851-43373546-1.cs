    <select>
        @{ var start = DateTime.Today.AddMonths(-14); }
            @for (var d = start; d < DateTime.Today.AddMonths(1); d = d.AddMonths(1))
            {
            <option value="@d.ToString("s")">@d.ToString("MMMM yyyy")</option>
            }
    </select>
