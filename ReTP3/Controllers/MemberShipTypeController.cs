using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReTP3.Models;

namespace ReTP3.Controllers
{
    public class MemberShipTypeController : Controller
    {
        private readonly AppDbContext _db;
        public MemberShipTypeController(AppDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            return _db.memberships != null ?
                          View(await _db.memberships.ToListAsync()) :
                          Problem("Entity set 'AppDbContext.MembershipTypes'  is null.");
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,SignUpFee,DurationInMonths,DiscountRate")] MemberShipType membershipType)
        {
            if (ModelState.IsValid)
            {
                membershipType.Id = new int();
                _db.Add(membershipType);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(membershipType);
        }
        
    }
}
