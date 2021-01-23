    @foreach (var item in Model)
    {
        if (item.Order >= 0 && item.Order <= 3)
        {
            if (item.Order == 0)
            {
                @:<tr>
            }
            <td class="lottery-unit lottery-unit-0"><img src="~/images/temp/1.png"></td>
            if (item.Order == 3)
            {
                 @:</tr>
            }
        }
    }
