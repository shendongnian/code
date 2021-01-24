        [Route("{some}/adress")]
        [HttpPatch]
        public bool YourDtoUpdate(long some, [FromBody]JsonPatchDocument<TestpDTO> testChanges)
        {
            var tsd = new TestDTO(){Nested = new NestedClass()};
            testChanges.ApplyTo(tsd);
        }
