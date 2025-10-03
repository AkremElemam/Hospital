using Hospital.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Controllers
{
    public class ViewReversationController : Controller
    {
        private ApplicationDbContext _dbContext = new ApplicationDbContext();
        public IActionResult Index()
        {
            var appoiments = _dbContext.Appointments.ToList();
            return View(appoiments);
        }
    }
}
