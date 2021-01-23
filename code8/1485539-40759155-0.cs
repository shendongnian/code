    int Id = 0;
    ObjectParameter prm = new ObjectParameter("Id", typeof(int));
    DB.SP_AccountModules_Insert(DTO.Area, DTO.Controller, DTO.Action, DTO.SubAction, DTO.Name, DTO.TopName, DTO.Level, DTO.Visible, DTO.Clickable, DTO.HomePage, DTO.Icon, DTO.Status, prm);
    Id = Convert.ToInt32(prm.Value);
    return Id;
