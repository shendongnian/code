    Map(m => m.DescricaoId)
        .Column("MPR_DS")
        .Not.Insert().Not.Update();
    Map(m => m.AtivoId)
        .Column("MPR_ATIVO")
        .Not.Insert().Not.Update();
