public interface IContactUseCase
{
    public Contact AddContact(ContactInputDto data);
    public List<Contact> GetContacts();
}