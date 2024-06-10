using Microsoft.EntityFrameworkCore;
using Tutorial10.Models;

namespace Tutorial10.Data;

public class PrescriptionContext: DbContext
{
    protected PrescriptionContext()
    {
    }

    public PrescriptionContext(DbContextOptions options) : base(options)
    {
    }
    
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Medicament> Medicaments { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Prescription> Prescriptions { get; set; }
    public DbSet<PrescriptionMedicament> PrescriptionMedicaments { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<Patient>().HasData(new List<Patient>
            {
                new Patient() {
                    IdPatient = 1,
                    FirstName = "Jan",
                    LastName = "Kowalski",
                    BirthDate = DateTime.Parse("2003-12-06")
                },
                new Patient() {
                    IdPatient = 2,
                    FirstName = "Anna",
                    LastName = "Nowak",
                    BirthDate = DateTime.Parse("2000-10-19")
                }
            });

            modelBuilder.Entity<Doctor>().HasData(new List<Doctor>
            {
                new Doctor() {
                    IdDoctor = 1,
                    FirstName = "Adam",
                    LastName = "Nowak",
                    Email = "adamn@gmail.com"
                },
                new Doctor() {
                    IdDoctor = 2,
                    FirstName = "Aleksandra",
                    LastName = "Wiśniewska",
                    Email = "alexawisnia@gmail.com"
                }
            });

            modelBuilder.Entity<Medicament>().HasData(new List<Medicament>
            {
                new Medicament()
                {
                    IdMedicament = 1,
                    Name = "Apam",
                    Description = "description1",
                    Type = "A"
                },
                new Medicament()
                {
                    IdMedicament = 2,
                    Name = "Positiwum",
                    Description = "Description2",
                    Type = "B"
                }
            });

            modelBuilder.Entity<Prescription>().HasData(new List<Prescription>
            {
                new Prescription()
                {
                    IdPrescription = 1,
                    Date= DateTime.Parse("2024-05-28"),
                    DueDate = DateTime.Parse("2024-05-29"),
                    IdPatient = 1,
                    IdDoctor = 2
                },
                new Prescription()
                {
                    IdPrescription = 2,
                    Date= DateTime.Parse("2024-02-28"),
                    DueDate = DateTime.Parse("2024-03-29"),
                    IdPatient = 2,
                    IdDoctor = 1
                }
            });

            modelBuilder.Entity<PrescriptionMedicament>().HasData(new List<PrescriptionMedicament>
            {
                new PrescriptionMedicament()
                {
                    IdMedicament = 1,
                    IdPrescription = 1,
                    Dose = null,
                    Details ="Details1" 
                    
                },
                new PrescriptionMedicament()
                {
                    IdMedicament = 2,
                    IdPrescription = 2,
                    Dose = 20,
                    Details = "Details2"
                }
            });
    }
}