    public async Task<IEnumerable<PI>> GetDataAsync() {
        var httpClinet = buildClient();
        var str = buildRequestUrl();
        var response = await httpClinet.GetAsync(str);
        IEnumerable<PI> caseInfos = Enumerable.Empty<PI>();
        if (response.IsSuccessStatusCode) {
            try {
                caseInfos = await response.Content.ReadAsAsync<IEnumerable<PI>>();
            } catch {
                //Log?
            }
            if (caseInfos == null) {
                try {
                    var singleObject = await response.Content.ReadAsAsync<PI>();
                    if (singleObject != null) {
                        caseInfos = new[] { singleObject };
                    }
                } catch {
                    //Log?
                }
            }
        }
        return caseInfos;
    }
