public class ContactUseCase : IContactUseCase
{
    private readonly IContactRepository _contactRepository;

    public ContactUseCase(IContactRepository contactRepository)
    {
        _contactRepository = contactRepository;
    }

    public Contact AddContact(ContactInputDto data)
    {   
        var response = _contactRepository.Save(new Contact
        {
            Name = data.Name
        });

        return response;
    }

    public List<Contact> GetContacts()
    {
        var response = _contactRepository.GetContacts();
        return response;
    }
}