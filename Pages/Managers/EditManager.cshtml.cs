using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SMS.DataContext;
using SMS.Hoang_Hieu_Hao.Service;
using SMS.Models;

namespace SMS.Hoang_Hieu_Hao.Pages.Managers

{
    public class EditManagerModel : PageModel
    {
        private readonly ManagerService _service;

        public EditManagerModel(ManagerService service)
        {
            _service = service;
        }

        [BindProperty]
        public Manager Managers { get; set; }

        public async Task<IActionResult> OnGetAsync(int? itemid)
        {
            if (itemid == null)
            {
                return NotFound();
            }
            var manager = _service.Managers.FirstOrDefault(p => p.Id == itemid);
            if (manager == null)
            {
                return NotFound();
            }
            Managers = manager;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _service.UpdateManager(Managers.Id, Managers);
            return RedirectToPage(nameof(Index));
        }
    }
}
