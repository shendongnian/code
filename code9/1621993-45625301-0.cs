    public class MotivoItem
    {
        public int MotivoLocalId { get; set; }
    
        public string Description { get; set; }
    }
    var motivoItems = new List<MotivoItem>();
    motivoItems.Add(new MotivoItem {MitivoLocalId = 1, Description = "Bad Parking" });
    motivoItems.Add(new MotivoItem { MitivoLocalId = 2, Description = "No Driver's License" });
    motivoItems.Add(new MotivoItem { MitivoLocalId = 3, Description = "No Reflective Vestg" });
    
    foreach (var motivoItem in motivoItems)
    {
        motivoPicker.Items.Add(motivoItem.Description);
    }
    
    var MotivoLocalID = motivoItems[motivoPicker.SelectedIndex].MotivoLocalID;
