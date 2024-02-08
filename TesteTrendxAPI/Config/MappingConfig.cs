using AutoMapper;
using ToDoListAPI.Data.ValueObjects;
using ToDoListAPI.Model;

namespace ToDoListAPI.Config
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config => {
                config.CreateMap<TaskVO, TaskToDo>();
                config.CreateMap<TaskToDo, TaskVO>();
            });
            return mappingConfig;
        }
    }
}
