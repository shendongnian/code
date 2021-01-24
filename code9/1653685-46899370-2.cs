    using System;
    using System.Threading.Tasks;
    public class C {
        public Task<bool> M() {
            return Task.FromResult(false); //no need to await here at all
        }
}
