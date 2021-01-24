    public class LstMaterialesCL : ObservableCollection<MaterialesCL>, INotifyPropertyChanged
    {
        public LstMaterialesCL()
        {
            BasculaEntities _context = new BasculaEntities();
            var Query = (from m in _context.Materiales
                             select new { m.Material, m.Descripcion}
                            ).OrderBy(m => m.Material).ToList();
            foreach (var item in Query)
            {
                this.Add(new MaterialesCL { Material = item.Material, 
                    Descripcion = item.Descripcion, DescCompuesta = item.Material.ToString("000") + " - " + item.Descripcion,
                IsChecked=false});
            }
        }
    }
