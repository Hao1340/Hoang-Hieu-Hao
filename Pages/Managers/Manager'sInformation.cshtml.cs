using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SMS.DataContext;
using SMS.Hoang_Hieu_Hao.Service;
using SMS.Models;

namespace SMS.Hoang_Hieu_Hao.Pages.Managers

{
    public class Manager_sInformationModel : PageModel
    {
        private readonly ManagerService _service;
        public IList<Manager> ManagerList { get; set; } = default!;

        [BindProperty]
        public Manager NewInfor { get; set; } = default!;

        public Manager_sInformationModel(ManagerService service)
        {
            _service = service;
        }
        public void OnGet()
        {
            ManagerList = _service.GetManagers();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid || NewInfor == null)
            {
                return Page();
            }

            _service.AddManager(NewInfor);

            return RedirectToAction("Get");
        }

        public IActionResult OnPostDelete(int id)
        {
            _service.DeleteManager(id);
            return RedirectToAction("Get");
        }
    }
}
