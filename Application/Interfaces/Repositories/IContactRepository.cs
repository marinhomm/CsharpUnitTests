public interface IContactRepository
{
    public Contact Save(Contact contact);
    public List<Contact> GetContacts();
}