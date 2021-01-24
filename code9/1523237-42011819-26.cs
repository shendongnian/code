    public interface IHasAssociation<out TAssociation>
    {
    	TAssociation Association
    	{
    		get;
    	}
    }
    
    public interface IHasManyAssociation<out TEnumerable, out TAssociation>
    		where TEnumerable : IEnumerable<TAssociation> 
    		where TAssociation : Entity
    {
    	TEnumerable Association
    	{
    		get;
    	}
    }
    
    public class Entity
    {
    }
    
    public class Company : Entity
    {
    }
    
    public class CustomerProfile : Entity
    {
    }
    
    public class Contact : Entity
    {
    }
    
    public class Customer : 
    	IHasAssociation<Company>, 
    	IHasAssociation<CustomerProfile>, 
    	IHasManyAssociation<IList<Contact>, Contact>
    {
    	public Company Company
    	{
    		get;
    		set;
    	}
    
    	public CustomerProfile Profile
    	{
    		get;
    		set;
    	}
    
    	public IList<Contact> Contacts
    	{
    		get;
    		set;
    	}
    
    	Company IHasAssociation<Company>.Association => Company;
    	CustomerProfile IHasAssociation<CustomerProfile>.Association => Profile;
    	IList<Contact> IHasManyAssociation<IList<Contact>, Contact>.Association => Contacts;
    }
