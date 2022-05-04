using DataAccess;
using Repository.Repositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TaskManagementEntities _context;

        public UnitOfWork(TaskManagementEntities context)
        {
            _context = context;
           Tasks = new TaskRepository(_context);
        }

        public TaskRepository Tasks { get; set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
