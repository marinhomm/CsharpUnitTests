using AutoFixture;
using Moq;
using System.Reflection.Metadata.Ecma335;

public class ContactUseCaseTest
{
    private readonly IContactUseCase _contactUseCase;
    private readonly Mock<IContactRepository> _contactRepositoryMock;
    private readonly Fixture _fixture;
    
    public ContactUseCaseTest()
    {   
        _contactRepositoryMock = new Mock<IContactRepository>();
        _contactUseCase = new ContactUseCase(_contactRepositoryMock.Object);
        _fixture = new Fixture();
    }

    [Fact]
    public void AddContactTest()
    {
        //Arrange
        _contactRepositoryMock.Setup(repo => repo.Save(It.IsAny<Contact>())).Returns((Contact contact) =>
        {
            contact.Id = Guid.NewGuid();
            return contact;
        });

        string contactName = _fixture.Create<string>();
        
        //Act
        var response = _contactUseCase.AddContact(new ContactInputDto { Name = contactName });

        //Assert
        Assert.IsType<Guid>(response.Id);
        Assert.Equal(contactName, response.Name);
        
    }

    [Fact]
    public void GetContactsTest()
    {
        //Arrange
        var expectedResult = new List<Contact>
        {
            new Contact { Id = Guid.NewGuid(), Name = _fixture.Create<string>() },
            new Contact { Id = Guid.NewGuid(), Name = _fixture.Create<string>() },
            new Contact { Id = Guid.NewGuid(), Name = _fixture.Create<string>() }
        };

        _contactRepositoryMock.Setup(repo => repo.GetContacts()).Returns(expectedResult);

        //Act
        var response = _contactUseCase.GetContacts();

        //Assert
        Assert.IsType<List<Contact>>(response);
    }
}