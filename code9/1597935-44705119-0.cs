    ContractID = ( SELECT ContractsMain.ContractsID 
                   FROM ContractsMain
                   INNER JOIN Contracts ON Contracts_ID = ContractsMain.ContractsID       ),
    SubjectContract = ( SELECT ContractsMain.SubjectContract
                        FROM ContractsMain
                       INNER JOIN Contracts ON Contracts_ID = ContractsMain.ContractsID   ),
