using System.ComponentModel.DataAnnotations;

public class ContactInputDto
{
    [Required(ErrorMessage = "Field 'name' can not be empty or null!")]
    public required string Name { get; set; }
}