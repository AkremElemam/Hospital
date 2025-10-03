using Hospital.DataAccess;
using Hospital.Models;
using Hospital.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Controllers
{
    public class ReserveController : Controller
    {
        private ApplicationDbContext _dbContext = new ApplicationDbContext();
        public IActionResult Index(FilterDoctorsVM filterDoctorsVM)
        {
            var doctors = _dbContext.Doctors.ToList();
            if (filterDoctorsVM.name is not null)
            {
                doctors = doctors.Where(e => e.Name.Contains(filterDoctorsVM.name ?? "")).ToList();
            }
            if (filterDoctorsVM.specialization is not null)
            {
                doctors = doctors.Where(e => e.Specialization.Contains(filterDoctorsVM.specialization ?? "")).ToList();
            }
            var specializations = _dbContext.Doctors.Select(d => d.Specialization).Distinct().ToList();
            ViewBag.specializations = specializations.Distinct().ToList();

            return View(doctors);
        }
        public IActionResult Appointment(int id)
        {
            var doctor = _dbContext.Doctors.FirstOrDefault(d => d.DoctorId == id);
            return View(doctor); 
        }
        [HttpPost]
        public IActionResult Appointment(int doctorId,string patientName,Appointment appointment)
        {
            _dbContext.Appointments.Add(new Appointment() { DoctorId = doctorId, AppointmentDate = appointment.AppointmentDate});

            return RedirectToAction("Index", "ViewReversation");
        }
    }
}
