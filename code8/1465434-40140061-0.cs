    public int BankStmntExceptionsDoProcess(string ckNo, string ckAmt, string checkNo, string checkAmt, string user)
        {
            int errCode = 0;;
            ckNo     = ckNo.Trim();
            ckAmt    = ckAmt.Trim();
            checkNo  = checkNo.Trim();
            checkAmt = checkAmt.Trim();
            user     = user.Trim();
            object obj = null;
            if (DBC == null)
                DBC = new DBConn();
            DBC.ExecutePackage(Vars.pkgBankStatementProcessing,
                               out obj,
                               new ParameterDirection[] { ParameterDirection.Input,
                                                          ParameterDirection.Input,
                                                          ParameterDirection.Input,
                                                          ParameterDirection.Input,
                                                          ParameterDirection.Input,
                                                          ParameterDirection.Output,
                                                        },
                               new object[] { ckNo, ckAmt, checkNo, checkAmt, user, errCode }
                               );
            errCode = int.Parse(obj.ToString());
            return errCode;
        }
