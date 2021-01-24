    jscript = string.Empty;
    if ( situacao != benOld.Situacao.Codigo && 
                                 situacao != (int) SituacaoBeneficiarioEnum.Suspenso &&
                                 benOld.Situacao.Codigo != (int)SituacaoBeneficiarioEnum.Suspenso &&
                                 datasituacao < benOld.DataSituacao &&
                                 datasituacao != Constants.NULLDATE)
    jscript = jscript + " var i; for (i = 0; i < Page_Validators.length; i++) { ValidatorValidate(Page_Validators[i]); } ValidatorUpdateIsValid();  if ( Page_IsValid ){ "+ Pergunta5()+" } ";
