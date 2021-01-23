    string test = "This movie is great. I like the story, acting is nice and direction is perfect but music is not good.";
    var splitVals = test.Split(new string[] 
    {   ",", ".", ";", " and ", " or ",
        " though ", " but ", " etc. "
    },StringSplitOptions.RemoveEmptyEntries);
