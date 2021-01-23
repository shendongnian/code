    public class DynamicDeserialisationStoreTests
    {
        private readonly FooSystemModel fooSystem;
        public DynamicDeserialisationStoreTests()
        {
            this.fooSystem = new FooSystemModel();
        }
        [Fact]
        public void Store_Should_Handle_Adding_Keyed_Model()
        {
            // GIVEN the foo system currently contains no foos.
            this.fooSystem.Foos.ShouldBeEmpty();
            // GIVEN a patch document to store a foo called "test".
            var request = "{\"op\":\"add\",\"path\":\"/foos/test\",\"value\":{\"number\":3,\"bazzed\":true}}";
            var operation = JsonConvert.DeserializeObject<Operation<FooSystemModel>>(request);
            var patchDocument = new JsonPatchDocument<FooSystemModel>(
                new[] { operation }.ToList(),
                new CamelCasePropertyNamesContractResolver());
            // WHEN we apply this patch document to the foo system model.
            patchDocument.ApplyTo(this.fooSystem);
            // THEN the system model should now contain a new foo called "test" with the expected properties.
            this.fooSystem.Foos.ShouldHaveSingleItem();
            FooModel foo = this.fooSystem.Foos["test"] as FooModel;
            foo.Number.ShouldBe(3);
            foo.IsBazzed.ShouldBeTrue();
        }
        [Fact]
        public void Store_Should_Handle_Removing_Keyed_Model()
        {
            // GIVEN the foo system currently contains a foo.
            var testFoo = new FooModel { Number = 3, IsBazzed = true };
            this.fooSystem.Foos["test"] = testFoo;
            // GIVEN a patch document to remove a foo called "test".
            var request = "{\"op\":\"remove\",\"path\":\"/foos/test\"}";
            var operation = JsonConvert.DeserializeObject<Operation<FooSystemModel>>(request);
            var patchDocument = new JsonPatchDocument<FooSystemModel>(
                new[] { operation }.ToList(),
                new CamelCasePropertyNamesContractResolver());
            // WHEN we apply this patch document to the foo system model.
            patchDocument.ApplyTo(this.fooSystem);
            // THEN the system model should be empty.
            this.fooSystem.Foos.ShouldBeEmpty();
        }
        [Fact]
        public void Store_Should_Handle_Modifying_Keyed_Model()
        {
            // GIVEN the foo system currently contains a foo.
            var originalFoo = new FooModel { Number = 3, IsBazzed = true };
            this.fooSystem.Foos["test"] = originalFoo;
            // GIVEN a patch document to modify a foo called "test".
            var request = "{\"op\":\"replace\",\"path\":\"/foos/test\", \"value\":{\"number\":6,\"bazzed\":false}}";
            var operation = JsonConvert.DeserializeObject<Operation<FooSystemModel>>(request);
            var patchDocument = new JsonPatchDocument<FooSystemModel>(
                new[] { operation }.ToList(),
                new CamelCasePropertyNamesContractResolver());
            // WHEN we apply this patch document to the foo system model.
            patchDocument.ApplyTo(this.fooSystem);
            // THEN the system model should contain a modified "test" foo.
            this.fooSystem.Foos.ShouldHaveSingleItem();
            FooModel foo = this.fooSystem.Foos["test"] as FooModel;
            foo.Number.ShouldBe(6);
            foo.IsBazzed.ShouldBeFalse();
        }
        #region Mock Models
        private class FooModel
        {
            [JsonProperty(PropertyName = "number")]
            public int Number { get; set; }
            [JsonProperty(PropertyName = "bazzed")]
            public bool IsBazzed { get; set; }
        }
        private class FooSystemModel
        {
            private readonly IDictionary<string, FooModel> foos;
            public FooSystemModel()
            {
                this.foos = new Dictionary<string, FooModel>();
                this.Foos = new DynamicDeserialisationStore<FooModel>(
                    storeValue: (name, foo) => this.foos[name] = foo,
                    removeValue: name => this.foos.Remove(name),
                    retrieveValue: name => this.foos[name],
                    retrieveKeys: () => this.foos.Keys);
            }
            [JsonProperty(PropertyName = "foos")]
            public IDictionary<string, object> Foos { get; }
        }
        #endregion
    }
