    [HttpPost]
    public ActionResult deleteAnswers(MyObject data)
    {
        Console.Write(data);
        Response.StatusCode = 200;
        return Content("Sucess");
    }
    
    public class MyObject {
        public List<Answer> Data { get; set; }
    }
    
    public class Answer {
        public int QuestionId { get; set; }
        public string Answer { get; set; }
    }
