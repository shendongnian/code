    [ParameterExists('approved', false)]
    public IActionResult ReportDetails(int? reportId){
        ....
    }
    
    [ParameterExists('approved', true)]
    public IActionResult ReportDetails(int? reportId, bool ? approved) {
        ....
    }
