using System.ComponentModel.DataAnnotations;

namespace Hospital.Models
{
    public class Doctor
    {
        public int DoctorId { get; set; }
        public string Name { get; set; }
        public string Specialization { get; set; }
        public string? ImageUrl { get; set; }
        public bool IsActive { get; set; } = true;

        // Relations
        public List<Appointment> Appointments { get; set; } = new();
    }

}
