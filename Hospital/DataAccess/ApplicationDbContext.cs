using Hospital.Models;
using Microsoft.EntityFrameworkCore;

namespace Hospital.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public object Patient { get; internal set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=.; Initial Catalog = Hospital; Integrated Security=True;" +
                "Connect Timeout=30;Encrypt=True; Trust Server Certificate=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Doctor
            modelBuilder.Entity<Doctor>()
                .HasKey(d => d.DoctorId);

            modelBuilder.Entity<Doctor>()
                .Property(d => d.Name)
                .HasMaxLength(100)
                .IsUnicode(true)
                .IsRequired();

            modelBuilder.Entity<Doctor>()
                .Property(d => d.Specialization)
                .HasMaxLength(100)
                .IsUnicode(true)
                .IsRequired();

            modelBuilder.Entity<Doctor>()
                .Property(d => d.ImageUrl)
                .HasMaxLength(255)
                .IsUnicode(false)
                .IsRequired(false);

            modelBuilder.Entity<Doctor>()
                .Property(d => d.IsActive)
                .HasDefaultValue(true)
                .IsRequired();

            // Patient
            modelBuilder.Entity<Patient>()
                .HasKey(p => p.PatientId);

            modelBuilder.Entity<Patient>()
                .Property(p => p.Name)
                .HasMaxLength(100)
                .IsUnicode(true)
                .IsRequired();

            modelBuilder.Entity<Patient>()
                .Property(p => p.PhoneNumber)
                .HasMaxLength(15)
                .IsUnicode(false)
                .IsRequired(false);

            modelBuilder.Entity<Patient>()
                .Property(p => p.RegisteredOn)
                .HasDefaultValueSql("GETUTCDATE()")
                .IsRequired();

            // Appointment
            modelBuilder.Entity<Appointment>()
                .HasKey(a => a.AppointmentId);

            modelBuilder.Entity<Appointment>()
                .Property(a => a.AppointmentDate)
                .IsRequired();

            modelBuilder.Entity<Appointment>()
                .Property(a => a.AppointmentTime)
                .IsRequired();

            modelBuilder.Entity<Appointment>()
                .Property(a => a.CreatedAt)
                .HasDefaultValueSql("GETUTCDATE()")
                .IsRequired();

            // Appointment  Doctor (Many-to-1)
            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Doctor)
                .WithMany(d => d.Appointments)
                .HasForeignKey(a => a.DoctorId);

            // Appointment  Patient (Many-to-1)
            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Patient)
                .WithMany(p => p.Appointments)
                .HasForeignKey(a => a.PatientId);

            //----------------------------------------------------------------------------------
            // Seeding Data
            //----------------------------------------------------------------------------------

            // Doctor Seed Data
            modelBuilder.Entity<Doctor>().HasData(
                new Doctor { DoctorId = 1, Name = "Dr. Ahmed Ali", Specialization = "Cardiology", ImageUrl ="docror1.jpg", IsActive=true },
                new Doctor { DoctorId = 2, Name = "Dr. Ramy Hassan", Specialization = "Dermatology", ImageUrl = "docror2.jpg", IsActive = true },
                new Doctor { DoctorId = 3, Name = "Dr. Youssef Adel", Specialization = "Neurology", ImageUrl = "docror3.jpg", IsActive = true },
                new Doctor { DoctorId = 4, Name = "Dr. Reda Kamal", Specialization = "Pediatrics", ImageUrl = "docror4.jpg", IsActive = true },
                new Doctor { DoctorId = 5, Name = "Dr. Karim Nabil", Specialization = "Orthopedics", ImageUrl = "docror5.png", IsActive = true },
                new Doctor { DoctorId = 6, Name = "Dr. Hany Mostafa", Specialization = "General Surgery", ImageUrl = "docror6.png", IsActive = false }
            );

            // Patient Seed Data
            modelBuilder.Entity<Patient>().HasData(
                   new Patient { PatientId = 1, Name = "Mohamed Saeed" },
                   new Patient { PatientId = 2, Name = "Sara Ali" }
            );
        }
    }
}
