        [Test]
        public void Test()
        {
            var model = new PersonModel {FirstName = "Bar", City = "New York"};
            var builder = new SqlBuilder();
            var selector = builder.AddTemplate("select * from table /**where**/");
            if (model.Id > 0)
                builder.Where("Id = @Id", new { model.Id });
            if (!string.IsNullOrEmpty(model.FirstName))
                builder.Where("FirstName = @FirstName", new { model.FirstName });
            if (!string.IsNullOrEmpty(model.Lastname))
                builder.Where("Lastname = @Lastname", new { model.Lastname });
            if (!string.IsNullOrEmpty(model.City))
                builder.Where("City = @City", new { model.City });
            Assert.That(selector.RawSql, Is.EqualTo("select * from table WHERE FirstName = @FirstName AND City = @City\n"));
            //var rows = sqlConnection.Query(selector.RawSql, selector.Parameters);
        }
