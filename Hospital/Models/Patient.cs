namespace Hospital.Models
{
    public class Patient
    {
        public int PatientId { get; set; }
        public string Name { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime RegisteredOn { get; set; } 
        // Relations
        public List<Appointment> Appointments { get; set; } = new();
    }
}
