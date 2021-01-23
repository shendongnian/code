            Type type = typeof(StudentViewModel);
            PropertyInfo[] properties = type.GetProperties();
            var infos = properties.Where(x => x.CustomAttributes.Any(y => y.AttributeType == typeof(IsViewable))).ToList();
            List<StudentViewModel> models = result.Item1;
            List<dynamic> list = models.Select(x => GetValue(x, infos)).ToList();
            string serializeObject = JsonConvert.SerializeObject(list);
            var deserializeObject = JsonConvert.DeserializeObject<List<dynamic>>(serializeObject);
            dataGridView1.DataSource = deserializeObject;
