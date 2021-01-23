        [Fact]
        public void Append_GivenArrayAndValue_ShouldBeValid()
        {
            // Simple collection parameter expansion
            _sql = Sql.Builder.Append("@0 IN (@1) @2", 20, new int[] { 1, 2, 3 }, 30);
            _sql.SQL.ShouldBe("@0 IN (@1,@2,@3) @4");
            _sql.Arguments.Length.ShouldBe(5);
            _sql.Arguments[0].ShouldBe(20);
            _sql.Arguments[1].ShouldBe(1);
            _sql.Arguments[2].ShouldBe(2);
            _sql.Arguments[3].ShouldBe(3);
            _sql.Arguments[4].ShouldBe(30);
        }
        [Fact]
        public void Append_GivenArrayAndNamedValue_ShouldBeValid1()
        {
            // Simple collection parameter expansion
            _sql = Sql.Builder.Append("@p1 IN (@p2) @p3", new { p1 = 20 }, new { p2 =  new int[] { 1, 2, 3 }}, new { p3 = 30 });
            _sql.SQL.ShouldBe("@0 IN (@1,@2,@3) @4");
            _sql.Arguments.Length.ShouldBe(5);
            _sql.Arguments[0].ShouldBe(20);
            _sql.Arguments[1].ShouldBe(1);
            _sql.Arguments[2].ShouldBe(2);
            _sql.Arguments[3].ShouldBe(3);
            _sql.Arguments[4].ShouldBe(30);
        }
