using FormTest.DataAccess.Models;
using FormTest.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FormTest.WebApp.Controllers
{
    [Authorize]
    public class ApplicationFormController : Controller
    {
        private readonly IApplicationFormService _service;

        public ApplicationFormController(IApplicationFormService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index(int page = 1, int pageSize = 10)
        {
            var forms = await _service.GetAllAsync(page, pageSize);
            return View(forms);
        }

        // 2. CREATE PAGE (The Empty Form)
        // GET: ApplicationForm/Create

        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        // 3. CREATE LOGIC (Receiving the Data)
        // POST: ApplicationForm/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(ApplicationForm form)
        {
            if (ModelState.IsValid)
            {
                await _service.CreateAsync(form);
                return RedirectToAction(nameof(Index));
            }
            return View(form);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id)
        {
            // Use the service to find the form with this specific ID
            var form = await _service.GetByIdAsync(id);

            // If it doesn't exist, return a "Not Found" 404 error
            if (form == null)
            {
                return NotFound();
            }

            // Send the existing form data to the View so the boxes are pre-filled
            return View(form);
        }

        [Authorize(Roles = "Viewer")]
        public async Task<IActionResult> Details(int id)
        {
            // Use the service to find the form with this specific ID
            var form = await _service.GetByIdAsync(id);

            // If it doesn't exist, return a "Not Found" 404 error
            if (form == null)
            {
                return NotFound();
            }

            // Send the existing form data to the View so the boxes are pre-filled
            return View(form);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(ApplicationForm form)
        {
            if (ModelState.IsValid)
            {
                // Call the Update method we wrote in the Service earlier
                await _service.UpdateAsync(form);
                return RedirectToAction(nameof(Index));
            }
            return View(form);
        }
    }
}
