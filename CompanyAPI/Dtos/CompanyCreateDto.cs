using System.ComponentModel.DataAnnotations;

namespace CompanyAPI.Dtos;

public class CompanyCreateDto
{
    [Required]
    public string CompanyName { get; set; }
    [Required]
    public string Email { get; set; }
    public string Address { get; set; }
    [Required]
    [MaxLength(12)]
    public string Nit { get; set; }
    [Required]
    public string Password { get; set; }
}
