    private class TmpDto {
        string UsuarioId { get; set;}
        string PerfilId { get; set;}
    }
    
    var Ilist<TmpDto> list = new List<TmpDto>();
    foreach (DataRow row in reader.Rows)
    {
    	var dto = new TmpDto();
    	dto.UsuarioId = row["UsuarioId"].ToString();
    	dto.UsuarioId = row["PerfilId"].ToString();
    	list.Add(dto);
    }    
    
