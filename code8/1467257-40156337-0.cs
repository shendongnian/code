     public class ResponseDto {
         public QueryDto Query {get; set;}
     }
     public class QueryDto {
         public IEnumerable<Query> Search {get; set;}
     }
     var data = JsonConvert.DeserializeObject<QueryDto>(json);
     var list = data.Query.Search.ToList();
