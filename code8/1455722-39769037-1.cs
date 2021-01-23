    QuestionMetadata qm = new QuestionMetadata();
    qm.PropInfo = typeof(TestClass).GetProperty("MyProperty");
    var myFunc = qm.CreateExpression<TestClass, int>().Compile();
    TestClass t = new TestClass();
    t.MyProperty = 10;
    MessageBox.Show(myFunc(t).ToString());
