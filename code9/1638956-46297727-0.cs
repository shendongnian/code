    using System.Data.Entity;
    public Task<bool> IsRegisteredCopy()
    {
        return context.Doctors.AnyAsync();
    }
