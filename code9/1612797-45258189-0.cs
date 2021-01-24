     public virtual I_Repository<I_Identifiable> CreateRepository(E_Repositories vrpRepository)
    {
        I_Repository<I_Identifiable> vrlRepository = null;
        switch (vrpRepository)
        {
            case E_Repositories.User:
                vrlRepository = new Cl_UserRepository() as I_Repository<I_Identifiable>;
                break;
        }
        return vrlRepository;
    }
