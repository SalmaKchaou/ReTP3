using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ReTP3.Models;

namespace ReTP3.Controllers
{
    public class CustomerController : Controller
    {
        private readonly AppDbContext _db;
        public CustomerController(AppDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            // Include the MemberShipType property in the query
            List<Customer> customers = _db.customers.Include(c => c.MemberShipType).ToList();
            return View(customers);
        }


        public IActionResult Create()
        {
            var members = _db.memberships.ToList();
            ViewBag.member = members.Select(members => new SelectListItem()
            {
                Text = members.Name,
                Value = members.Id.ToString()
            });
            return View();
        }
        [HttpPost]
        public IActionResult Create(String Name, int MemberShipId)
        {
            if (ModelState.IsValid)
            {
                Customer c = new Customer()
                { Name = Name,
                  MemberShipId =MemberShipId ,
                }; 
                _db.customers.Add(c);
                    _db.SaveChanges();
                return (RedirectToAction(nameof(Index)));
            }
            ViewBag.Errors = ModelState
                            .Values
                            .SelectMany(x => x.Errors)
                            .Select(x => x.ErrorMessage).ToList();
            return (View());
            /*if (!ModelState.IsValid)
            {
                ViewBag.Errors = ModelState
                    .Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage);
                var members = _db.memberships.ToList();
                ViewBag.member = members.Select(members => new SelectListItem()
                {
                    Text = members.Name,
                    Value = members.Id.ToString()
                });
                return View(customer);
            }

            _db.customers.Add(customer);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));*/

        }
        
    }
}
