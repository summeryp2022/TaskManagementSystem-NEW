using DataAccess;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;


namespace Repository.Repositorys
{
    public class TaskRepository : GenericRepository<Task>, ITaskRepository
    {
        public TaskRepository(TaskManagementEntities taskManagementEntities) : base(taskManagementEntities)
        {
        }
    }
}
