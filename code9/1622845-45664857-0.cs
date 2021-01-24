    private async Task<List<Staff>> getAllStaff() {
        var resultList = new List<Staff>();
        var client = new HttpClient();
        var response = await client.GetAsync("http://localhost:8000/api/staff");
        if (response.StatusCode == System.Net.HttpStatusCode.OK) {
            bool arrayFailed = false;
            try {
                resultList = await response.Content.ReadAsAsync<List<Staff>>();
            } catch (Exception ex) {//Array parse failed so try single
                arrayFailed = true;
            }
            try {
                var staff = await response.Content.ReadAsAsync<Staff>();
                if (staff != null) {
                    resultList.Add(staff);
                }
            } catch (Exception ex) {
            }
        }
        return resultList;
    }
