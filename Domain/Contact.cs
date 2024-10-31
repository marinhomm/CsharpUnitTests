using System.ComponentModel.DataAnnotations;

public class Contact
{
    [Key]
    public Guid Id { get; set; }
    public required string Name { get; set; }
}