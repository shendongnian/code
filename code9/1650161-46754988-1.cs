    public class GenericsInArrayTests
    {
        [Fact]
        public void QuestionArrayTest()
        {
            Verify.QuestionArray();
        }
        [Fact]
        public void BadAnswerTest()
        {
            Verify.BadAnswerArray();
        }
        [Fact]
        public void GoodAnswerTest()
        {
            Verify.GoodAnswer();
        }
    }
