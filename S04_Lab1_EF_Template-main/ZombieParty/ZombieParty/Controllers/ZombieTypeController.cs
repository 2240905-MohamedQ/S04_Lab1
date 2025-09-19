using Microsoft.AspNetCore.Mvc;
using ZombieParty.Models;
using ZombieParty.Models.Data; // Vérifie si ton DbContext est bien ici
using ZombieParty.ViewModels;
using System.Linq;

namespace ZombieParty.Controllers
{
    public class ZombieTypeController : Controller
    {
        private readonly ZombiePartyDbContext _baseDonnees;

        public ZombieTypeController(ZombiePartyDbContext baseDonnees)
        {
            _baseDonnees = baseDonnees;
        }

        // GET: ZombieType
        public IActionResult Index()
        {
            var zombieTypesList = _baseDonnees.ZombieTypes.ToList();
            return View(zombieTypesList);
        }

        // GET: ZombieType/Details
        public IActionResult Details(int id)
        {
            var zombieType = _baseDonnees.ZombieTypes.FirstOrDefault(zt => zt.Id == id);
            if (zombieType == null)
            {
                return NotFound();
            }

            var zombies = _baseDonnees.Zombies.Where(z => z.ZombieTypeId == id);

            var zombieTypeVM = new ZombieTypeVM
            {
                ZombieType = zombieType,
                ZombiesList = zombies.ToList(),
                ZombiesCount = zombies.Count(),
                PointsAverage = zombies.Any() ? zombies.Average(p => p.Point) : 0
            };

            return View(zombieTypeVM);
        }

        // GET: ZombieType/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ZombieType/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ZombieType zombieType)
        {
            if (ModelState.IsValid)
            {
                _baseDonnees.ZombieTypes.Add(zombieType);
                _baseDonnees.SaveChanges(); 
                TempData["Success"] = $"{zombieType.TypeName} zombie type added";
                return RedirectToAction(nameof(Index));
            }

            return View(zombieType);
        }
    }
}
