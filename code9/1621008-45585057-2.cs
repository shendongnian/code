    public interface IImmaginiContainer
    {
      IEnumerable<IImmagine> Immagini { get; }
    }
    public class NewWrapper : IImmaginiContainer
    {
      public NewWrapper(New source)
      {
        _source = source;
      }
      private readonly New _source;
      public IEnumerable<IImmagine> Immagini => _source.Immagini;
    }
    // Create a similar class for Scheda and Pagina
    private void BuildFoto(RepeaterItemEventArgs e, IImaginiContainer item, string id)
    {
        var immagine = item.Immagini.Cast<Allegato>().Where(p => p.Categoria == id).FirstOrDefault();
        if (immagine != null)
        {
            // ...
        }
    }
