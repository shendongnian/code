        async Task Run() {
            List<Task<IResult>> tasks = new List<Task<IResult>>();
            if (someCondition) {
                tasks.Add(RunSome(someParams));
            }
            if (othercondition) {
                tasks.Add(RunOther(otherParam));
            }
            IResult[] results = await Task.WhenAll(tasks);
            foreach (var result in results) {
                if (result is SomeResult someResult) {
                    // Handle some result
                }
                else if (result is OtherResult otherResult) {
                    // Handle other result
                }
            }
        }
        static async Task<SomeResult> RunSome(someParams) {
            // Run something
        }
        static async Task<OtherResult> RunOther(otherParams) {
            // Run other thing
        }
        interface IResult {
        }
        class SomeResult : IResult {
        }
        class OtherResult: IResult {
        }
