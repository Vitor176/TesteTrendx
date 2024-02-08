using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoListAPI.Data.ValueObjects;
using ToDoListAPI.Model;
using ToDoListAPI.Model.Context;

namespace ToDoListAPI.Repository
{
    public class ToDoRepository : IToDoRepository
    {
        private readonly SqlContext _context;
        private IMapper _mapper;
        private readonly Messages.Messages _messages;

        public ToDoRepository(SqlContext context, IMapper mapper, Messages.Messages messages)
        {
            _context = context;
            _mapper = mapper;
            _messages = messages;
        }

        public async Task<IEnumerable<TaskVO>> FindAll()
        {
            Log.Information(_messages.SearchAnyIntoDatabase(nameof(_context.Tasks)));
            List<TaskToDo> tasks = await _context.Tasks.ToListAsync();
            return _mapper.Map<List<TaskVO>>(tasks);
        }

        public async Task<TaskVO> FindById(long id)
        {
            TaskToDo product =
                await _context.Tasks.Where(x => x.Id == id)
                .FirstOrDefaultAsync();
            return _mapper.Map<TaskVO>(product);
        }

        public async Task<TaskVO> Create(TaskVO vo)
        {
            TaskToDo task = _mapper.Map<TaskToDo>(vo);
            Log.Information(_messages.CreateTaskIntoDataBase(task));
            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();
            return _mapper.Map<TaskVO>(task);
        }
        public async Task<TaskVO> Update(TaskVO vo, long id)
        {
            TaskToDo TaskInBank =
               await _context.Tasks.Where(x => x.Id == id)
                   .FirstOrDefaultAsync();

            if (TaskInBank is not null)
            {

                Log.Information(_messages.UpdateTaskExisting(TaskInBank));

                TaskToDo TaskForUpdate = _mapper.Map<TaskToDo>(vo);
                TaskInBank.Title = TaskForUpdate.Title;
                TaskInBank.Description = TaskForUpdate.Description;
                TaskInBank.Completed = TaskForUpdate.Completed;

                _context.Tasks.Update(TaskInBank);
                await _context.SaveChangesAsync();
            }

            return _mapper.Map<TaskVO>(TaskInBank);

        }

        public async Task<bool> Delete(long id)
        {
            try
            {
                TaskToDo product =
                await _context.Tasks.Where(x => x.Id == id)
                    .FirstOrDefaultAsync();
                if (product == null) return false;
                _context.Tasks.Remove(product);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }

    }
}
