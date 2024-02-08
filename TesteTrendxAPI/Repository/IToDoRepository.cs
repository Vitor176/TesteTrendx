using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoListAPI.Data.ValueObjects;

namespace ToDoListAPI.Repository
{
    public interface IToDoRepository
    {
        Task<IEnumerable<TaskVO>> FindAll();
        Task<TaskVO> FindById(long id);
        Task<TaskVO> Create(TaskVO vo);
        Task<TaskVO> Update(TaskVO vo, long id);
        Task<bool> Delete(long id);
    }
}
