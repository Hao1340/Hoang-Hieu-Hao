
using Microsoft.AspNetCore.Mvc;
using SMS.DataContext;
using SMS.Models;

namespace SMS.Hoang_Hieu_Hao.Service
{
    public class ManagerService
    {
         
        //private readonly PizzaContext _context = default!;
        private readonly ManagerContext _context = default!;
        public IList<Manager> Managers { get; set; }
        public ManagerService(ManagerContext context)
        {
            _context = context;
            Managers = GetManagers();
        }

        public IList<Manager> GetManagers()
        {
            if (_context.Managers != null)
            {
                return _context.Managers.ToList();
            }
            return new List<Manager>();
        }
        public void AddManager(Manager manager)
        {
            if (_context.Managers != null)
            {
                _context.InsertManager(manager);

            }
        }
        public void UpdateManager(int id, Manager manager)
        {
            if (_context.Managers != null)
            {
                _context.UpdateManager(id, manager);
            }
        }

        public void DeleteManager(int id)
        {
            if (_context.Managers != null)
            {
                var pizza = _context.Managers.Find(p => p.Id == id);
                if (pizza != null)
                {
                    _context.DeleteManager(id);

                }
            }
        }
    }
}
