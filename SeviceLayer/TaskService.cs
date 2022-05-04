using DataAccess;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SeviceLayer.Models;
using AutoMapper;

namespace SeviceLayer
{
    public class TaskService
    {
        MapperConfiguration config;
        IMapper mapper;
        public UnitOfWork uow { get; set; }
        public TaskService()
        {
            TaskManagementEntities TaskEntities = new TaskManagementEntities();
            uow = new UnitOfWork(TaskEntities);
            config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Task, TaskDTO>();
                cfg.CreateMap<TaskDTO,Task>();
            });
            mapper = config.CreateMapper();
        }

        public TaskDTO GetInfoByID(int Id)
        {
            var Task1=uow.Tasks.GetByID(Id);
            if(Task1!=null)
            {
                return mapper.Map<Task,TaskDTO>(Task1);
            }
            else
            {
                return null;
            }
        }
        public bool DeleteTask(int Id)
        {
            var Task1 = uow.Tasks.GetByID(Id);
            if (Task1 != null)
            {
                uow.Tasks.Remove(Task1);
                uow.Complete();
                return true;
            }
            else
            {
                return false;
            }
        }
        public void PostInfo(Task taskNew)
        {
            
            uow.Tasks.Add(taskNew);
            uow.Complete();
            
        }
        public Task PushInfo(int id, Task taskNew)
        {
            var Task1 = uow.Tasks.GetByID(id);
            if (Task1 != null)
            {
                Task1.QuoteType = taskNew.QuoteType;
                Task1.Contact = taskNew.Contact;
                Task1.DueDate = taskNew.DueDate;
                Task1.Task1 = taskNew.Task1;
                Task1.TaskType = taskNew.TaskType;
                uow.Complete();
                return Task1;
            }
            else
                return null;
            

        }


    }
}
