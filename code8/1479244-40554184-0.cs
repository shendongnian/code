    using System.Linq;
    public class CupomItensViewModel
    {
        public IEnumerable<TabelaPrecoViewModel> TabelasPreco { get; set; }
        public TabelaPrecoViewModel TabelaPrecoSelecionada { get; set; }
        public IEnumerable<SelectListItem> TabelasPrecoSelectList
        {
            get 
            {
               return TabelasPreco.Select(x => new SelectListItem() 
                      {
                        Value = x.IdTabela
                        Text = x.NomeTabela
                        Selected = TabelaPrecoSelecionada.IdTabela
                      }
            }
        }
    }
