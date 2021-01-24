    using System;
    using System.Threading.Tasks;
    public class C {
        public async Task<bool> M() {
            return false;
        }
        
        public async Task<bool> M2(){
            return await Task.FromResult(false);
        }
        
        public Task<bool> M3(){
            return Task.FromResult(false);
        }
    }
