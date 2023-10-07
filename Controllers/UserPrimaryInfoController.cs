using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcAppPOC.Data;
using MvcAppPOC.Entities;

namespace MvcAppPOC.Controllers
{
    [Authorize] // Add authorization attribute to ensure only authenticated users can access this controller
    public class UserPrimaryInfoController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager; // Inject UserManager

        public UserPrimaryInfoController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager; // Initialize UserManager
        }

        // GET: UserPrimaryInfo
        public async Task<IActionResult> Index()
        {
            var currentUser = await _userManager.GetUserAsync(User);

            if (currentUser != null)
            {
                // Filter UserPrimaryInfo records by the current user's ID
                var userPrimaryInfoList = await _context.UserPrimaryInfo
                    .Include(u => u.User)
                    .Where(u => u.UserId == currentUser.Id)
                    .ToListAsync();

                return View(userPrimaryInfoList);
            }
            else
            {
                // Handle the case where the current user is not found
                return NotFound("Current user not found.");
            }
        }

        // GET: UserPrimaryInfo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userPrimaryInfo = await _context.UserPrimaryInfo
                .Include(u => u.User)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (userPrimaryInfo == null)
            {
                return NotFound();
            }

            return View(userPrimaryInfo);
        }

        // GET: UserPrimaryInfo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UserPrimaryInfo/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,JobTitle,Age")] UserPrimaryInfo userPrimaryInfo)
        {
            if (ModelState.IsValid)
            {
                // Get the current user
                var currentUser = await _userManager.GetUserAsync(User);

                if (currentUser != null)
                {
                    // Set the UserId property to the current user's ID
                    userPrimaryInfo.UserId = currentUser.Id;

                    _context.Add(userPrimaryInfo);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    // Handle the case where the current user is not found
                    return NotFound("Current user not found.");
                }
            }
            return View(userPrimaryInfo);
        }

        // GET: UserPrimaryInfo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userPrimaryInfo = await _context.UserPrimaryInfo.FindAsync(id);
            if (userPrimaryInfo == null)
            {
                return NotFound();
            }
            return View(userPrimaryInfo);
        }

        // ... (Other actions like Edit, Delete, etc.)

        private bool UserPrimaryInfoExists(int id)
        {
            return _context.UserPrimaryInfo.Any(e => e.Id == id);
        }
    }
}
