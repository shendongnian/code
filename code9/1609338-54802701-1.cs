        [Fact]
        public void Foo()
        {
            var world = "World";
            var someInt = 42;
            var unused = "Not used";
            //This is a normal string, it can be retrieved from config
            var myString = "Hello {world}, this is {someInt}";
            
            //You need to pass all local values that you may be using in your string interpolation. Pass them all as one single anonymous object.
            var result = myString.Interpolate(new {world, someInt, unused});
            result.Should().Be("Hello World, this is 42");
        }
