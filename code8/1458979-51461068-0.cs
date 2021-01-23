    [EnableQuery]
    public IActionResult Get([FromQuery] string name)
    {
            switch (name)
            {
                case "Movie2":
                    return Ok(new List<ViewModel>{new ViewModel(Movies2=_db.Movies2)});
            }
            return Ok(new List<ViewModel>{new ViewModel(Movies1=_db.Movies1)});
     }
