    private async Task<List<Staff>> getAllStaff() {
        var resultList = new List<Staff>();
        var client = new HttpClient();
        var response = await client.GetAsync("http://localhost:8000/api/staff");
        if (response.StatusCode == System.Net.HttpStatusCode.OK) {
            bool arrayParseFailed = false;
            try {
                resultList = await response.Content.ReadAsAsync<List<Staff>>();
            } catch (Exception ex) {//Array pase failed so try single
                arrayParseFailed = true;
            }
            if (arrayParseFailed) {
                try {
                    var staff = await response.Content.ReadAsAsync<Staff>();
                    if (staff != null) {
                        resultList.Add(staff);
                    }
                } catch (Exception ex) {
                }
            }
        }
        return resultList;
    }
