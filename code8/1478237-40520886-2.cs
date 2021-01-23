    @foreach (var test in ViewBag.CF_list)
    {    
        if (!string.IsNullOrWhiteSpace(test.Text))
        {
            <div class="checkbox">
                <label>
                    @Html.Checkbox("CF_list_", test.IsChecked, new { Value = test.Value }) @test.Text
                </label>
            </div>
        }
    }
