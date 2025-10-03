using System.ComponentModel.DataAnnotations;

namespace Hospital.Models
{
    public class Appointment
    {
        public int AppointmentId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public TimeSpan AppointmentTime { get; set; }
        public DateTime CreatedAt { get; set; } 

        // Doctor Relation
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }

        // Patient Relation
        public int PatientId { get; set; } 
        public Patient Patient { get; set; }
    }
}
