public class ContactRepository : IContactRepository
{
    private readonly AppDbContext _appDbContext;

    public ContactRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public Contact Save(Contact contact)
    {
        var response = _appDbContext.Add(contact);
        _appDbContext.SaveChanges();
        return response.Entity;
    }

    public List<Contact> GetContacts()
    {
        var response = _appDbContext.Contacts.ToList();
        return response;
    }
}