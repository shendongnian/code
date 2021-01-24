    using (var client = new HttpClient())
            {
                var commentPath = $"http://www.reddit.com/comments/{questionId}.json?sort=top";
                HttpResponseMessage commentResponse = client.GetAsync(commentPath).Result;
                var commentJson = commentResponse.Content.ReadAsStringAsync().Result;
                var answers = JsonConvert.DeserializeObject<reddit[]>(commentJson);
                int commentCount = 0;
                foreach (var answerContainer in answers[1].data.children)
                {
                }
            }
