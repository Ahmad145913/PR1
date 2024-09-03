using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Authorize(Roles = "FaciltyOwner")]

    public class DashboardController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly UserManager<ApplicationUser> _userManager;

        public DashboardController(ApplicationDbContext dbContext, UserManager<ApplicationUser> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _userManager.FindByIdAsync(userId);
            var facilities = _dbContext.MedicalFacilities
                .Include(f => f.Location)
                .Include(f => f.FacilityType)
                .Where(f => f.ManagerId == userId)
                .ToList();
            return View(facilities);
        }
        [HttpGet]
        public async Task<IActionResult> CreateMedicalFacility()
        {
            ViewBag.Locations = new SelectList(_dbContext.Locations, "Id", "LocationName");
            ViewBag.Managers = new SelectList(_dbContext.Users, "Id", "UserName");
            ViewBag.FacilityTypes = new SelectList(_dbContext.FacilityTypes, "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateMedicalFacility(MedicalFacilityDto medicalFacilityDto)
        {
            if (!ModelState.IsValid)
            {
                return View(medicalFacilityDto);
            }

            try
            {
                // Find or create Location
                var location = await _dbContext.Locations.FindAsync(medicalFacilityDto.LocationId);
                if (location == null)
                {
                    ModelState.AddModelError(string.Empty, $"Location with ID '{medicalFacilityDto.LocationId}' not found.");
                    return View(medicalFacilityDto);
                }

                // Find or create Manager
                var manager = await _dbContext.Users.FindAsync(medicalFacilityDto.ManagerId);
                if (manager == null)
                {
                    ModelState.AddModelError(string.Empty, $"Manager with ID '{medicalFacilityDto.ManagerId}' not found.");
                    return View(medicalFacilityDto);
                }

                // Find or create FacilityType
                var facilityType = await _dbContext.FacilityTypes.FindAsync(medicalFacilityDto.FacilityTypeId);
                if (facilityType == null)
                {
                    ModelState.AddModelError(string.Empty, $"Facility Type with ID '{medicalFacilityDto.FacilityTypeId}' not found.");
                    return View(medicalFacilityDto);
                }

                // Create MedicalFacility 
                var medicalFacility = new MedicalFacility
                {
                    Id = medicalFacilityDto.Id,
                    LocationId = location.Id,
                    ManagerId = manager.Id,
                    FacilityTypeId = facilityType.Id,
                    PhoneNumber = medicalFacilityDto.PhoneNumber,
                    EmergencyNumber = medicalFacilityDto.EmergencyNumber,
                    FaxNumber = medicalFacilityDto.FaxNumber,
                    CountryCode = medicalFacilityDto.CountryCode,
                    PictureUrl = medicalFacilityDto.PictureUrl,
                    CreatedAt = DateTime.UtcNow 
                };

                _dbContext.MedicalFacilities.Add(medicalFacility);
                await _dbContext.SaveChangesAsync();
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine($"Error creating Medical Facility: {ex.Message}");
                ModelState.AddModelError(string.Empty, "An error occurred while creating the Medical Facility.");
                return View(medicalFacilityDto);
            }
        }

    }
}
