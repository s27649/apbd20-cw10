using System.ComponentModel.DataAnnotations;

namespace Tutorial10.Models;

public class Doctor
{
    [Key]
    public int IdDoctor { get; set; }
    [MaxLength(100)]
    public string FirstName { get; set; } = string.Empty;
    [MaxLength(100)]
    public string LastName { get; set; } = string.Empty;
    [MaxLength(100)]
    public string Email { get; set; } = string.Empty;

    public ICollection<Prescription> Prescriptions { get; set; } = new HashSet<Prescription>();
}