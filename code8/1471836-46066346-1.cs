    [ViewIfAcceptHtml]
    [Route("/foo/")]
    public IActionResult Get(){ 
            return Ok(new Foo());
    }
