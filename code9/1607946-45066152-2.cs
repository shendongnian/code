            var _json =
                "[{  \"FormId\":\"1\",  \"Status\":true,  \"Version\":1},{  \"FormId\":\"1\",  \"Status\":true,  \"Version\":2},{  \"FormId\":\"2\",  \"Status\":true,  \"Version\":1},{  \"FormId\":\"2\",  \"Status\":true,  \"Version\":2},{  \"FormId\":\"2\",  \"Status\":false,  \"Version\":1}]";
            var js = new JavaScriptSerializer();
            List<Form> resultList = js.Deserialize<List<Form>>(_json);
            var groupedResult = resultList.Where(x => x.Status).GroupBy(item => new { item.FormId, item.Status })
                .Select(x =>
                    new Form
                    {
                        FormId = x.First().FormId,
                        Status = x.First().Status,
                        Version = x.OrderByDescending(c => c.Version).First().Version
                    }
                ).ToList();
            var output = js.Serialize(groupedResult);
