    ITurmaBLO bloT = ninjectKernel.Get<ITurmaBLO>();
    ICursoBLO blo = ninjectKernel.Get<ICursoBLO>();
    Turma t = Mapper.Map<TurmaDto, Turma>(dto);
    if(!(bloT.Update(t) && bloC.Update(t.Curso))){
          response = Request.CreateResponse(HttpStatusCode.NotFound, "Turma não encontrada.");
    }
