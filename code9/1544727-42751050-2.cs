    public async Task<IEnumerable<SelectListItem>> GrabEmployees()
    {
        var item = new List<SelectListItem>();
        using (var employee = new HttpClient())
        {
            employee.BaseAddress = new Uri("yourUrlForApiEndpointHere");
            employee.DefaultRequestHeaders.Accept.Clear();
            employee.DefaultRequestHeaders.Accept
                                .Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await employee.GetAsync("api/employees");
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsAsync<List<EmployeeViewModel>>();
                return data.Select(x => new SelectListItem { Value = x.EmployeeNumber,
                                               Text = (x.FirstName + " " + x.LastName) });
            }
        }
        return item;
    }
