    public class Processador {
        private readonly IFilaRepositorio _repoFila;
        public Processador(IFilaRepositorio  repoFila) {
            _repoFila = repoFila;
        }
    
        public void Processar() {
            _repoFila.SomeCustomMethod(); // <-- works
        }
    }
