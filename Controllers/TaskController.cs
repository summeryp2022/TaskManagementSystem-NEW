using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using DataAccess;
using System.Web;
using System.Web.Security;
using System;
using TaskManagementSystem.Models;
using Repository;
using AutoMapper;
using SeviceLayer;
using SeviceLayer.Models;


namespace TaskManagementSystem.Controllers
{
    [BasicAuthentication]
    public class TaskController : ApiController
    {
        MapperConfiguration config;
        IMapper mapper;
        TaskService taskService;
        private readonly TaskManagementEntities _taskManagementEntities;
        private readonly UnitOfWork _uow;
        public TaskController()
        {
            taskService = new TaskService();
            config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TaskDTO, TaskVM>();
                cfg.CreateMap<Task, TaskDTO>();
                cfg.CreateMap<TaskDTO, Task>();
                cfg.CreateMap<TaskVM, TaskDTO>();
            });
            mapper = config.CreateMapper();

            this._taskManagementEntities = new TaskManagementEntities();
            _uow = new UnitOfWork(_taskManagementEntities);
        }

        //api/Task
        [HttpGet]
        public List<TaskDTO> Get()
        {
           IEnumerable<Task> tasks= taskService.uow.Tasks.GetAll();
            List<TaskDTO> taskDTOs = new List<TaskDTO>();
            foreach (var task in tasks)
            {
                taskDTOs.Add(mapper.Map<Task, TaskDTO>(task));
            }
            
            return taskDTOs;


        }

        //api/Task/2
        [HttpGet]
        public TaskVM Get(int id)
        {
               var TaskDTO=taskService.GetInfoByID(id);
               var TaskVM = mapper.Map<TaskDTO, TaskVM>(TaskDTO);
            
                return TaskVM;

        }

        [HttpPut]
        public HttpResponseMessage Put(int id, [FromBody] Task task)
        {
            var tasknew = taskService.PushInfo(id, task);
            if (tasknew != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, tasknew);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Task not found");
            }


        }

        //api/Task
        [HttpPost]
        public string Post([FromBody] Task taskNew)
        {
           if(taskNew == null)
            {
                return "Value should not be null";
            }
            taskService.PostInfo(taskNew);
            return "Post successfully";
            

        }

        //api/Task
        [HttpDelete]
        public string Delete(int id)
        {
            bool task = taskService.DeleteTask(id);
            if (task)
            {
                return "Delete successfully";
            }
            else
                return " No Task ID= " + id + " is found";

        }


      
       
       }


}
