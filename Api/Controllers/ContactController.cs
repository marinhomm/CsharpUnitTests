using Microsoft.AspNetCore.Mvc;

public class ContactController : Controller
{
    private readonly IContactUseCase _contactUseCase;

    public ContactController(IContactUseCase contactUseCase)
    {
        _contactUseCase = contactUseCase;
    }
    
    [HttpPost]
    public IActionResult AddContact([FromBody] ContactInputDto data)
    {
        if(!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        try
        {
            var response = _contactUseCase.AddContact(data);
            return CreatedAtAction("AddContact", response);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    [HttpGet]
    public IActionResult GetContacts()
    {
        try
        {
            var response = _contactUseCase.GetContacts();
            return Ok(response);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }
}