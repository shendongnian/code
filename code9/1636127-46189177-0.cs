    public IActionResult GetSomeData(){
        if (CheckAccessCondition()){
            return Json(myData);
        }
        else{
            return Unauthorized();
        }
    }
