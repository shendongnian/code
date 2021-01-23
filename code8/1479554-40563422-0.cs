        public async Task<dynamic> FooAsync(dynamic parameters, CancellationToken cancellationToken) {
            return await Task.FromResult("x");
        }
        public async Task<dynamic> TryAsync(Func<Task<dynamic>> func) {
            try {
                return await func(); // Doesn't compile. Says it missing the 2 arguments.
            }
            catch (Exception exception) {
                return Task.FromResult(false);
            }
        }
        public async Task PewPewAsync() {
            var parameters = "x";
            var cancellationToken = CancellationToken.None;
            var result = await TryAsync(() => FooAsync(parameters, cancellationToken));
        }
