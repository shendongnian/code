List&lt;string&gt; strings = new List&ltstring&gt;(new[]
{
   "London 4",
   "Berlin 6", 
   "Paris 2",
   "Roma 7",
   "Istanbul 5"
});
var result = strings.OrderByDescending(s => int.Parse(s.Split()[1]));
