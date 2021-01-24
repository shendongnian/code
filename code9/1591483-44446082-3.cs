    public interface IFilaRepositorio : IRepositorio<FilaModel> {
        void SomeCustomMethod();
    }
    public class FilaRepositorio : Repositorio<FilaModel>, IFilaRepositorio {
        public void SomeCustomMethod() {
            //...other code removed for brevity.
        }
    }
