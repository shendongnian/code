    public class Processador
    {
        private IFilaRepositorio _repoFila;
        public Processador(IFilaRepositorio  repoFila)
        {
            _repoFila = repoFila;
        }
        public void Processar()
        {
            _repoFila.SomeCustomMethod();
        }
    }
