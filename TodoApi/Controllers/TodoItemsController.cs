using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

namespace TodoApi.Controllers
{
    [Route("api/Todoitems")]
    [ApiController]
    public class TodoItemsController : ControllerBase
    {
        private readonly ToDoContext _context;

        public TodoItemsController(ToDoContext context)
        {
            _context = context;
        }

        // GET: api/TodoItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ToDoItemDTO>>> GetToDoItems()
        {
            return await _context.ToDoItems
            .Select(x => ItemToDTO(x))
            .ToListAsync();
        }

        // GET: api/TodoItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ToDoItemDTO>> GetToDoItem(long id)
        {
            var toDoItem = await _context.ToDoItems.FindAsync(id);

            if (toDoItem == null)
            {
                return NotFound();
            }

            return ItemToDTO(toDoItem);
        }

        // PUT: api/TodoItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
    public async Task<IActionResult> PutTodoItem(long id, ToDoItemDTO todoDTO)
    {
        if (id != todoDTO.Id)
        {
            return BadRequest();
        }

        var todoItem = await _context.ToDoItems.FindAsync(id);
        if (todoItem == null)
        {
            return NotFound();
        }

        todoItem.Name = todoDTO.Name;
        todoItem.isComplete = todoDTO.isComplete;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException) when (!TodoItemExists(id))
        {
            return NotFound();
        }

        return NoContent();
    }
        // POST: api/TodoItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<ToDoItemDTO>> PostTodoItem(ToDoItemDTO todoDTO)
    {
        var todoItem = new ToDoItem
        {
            isComplete = todoDTO.isComplete,
            Name = todoDTO.Name
        };

        _context.ToDoItems.Add(todoItem);
        await _context.SaveChangesAsync();

        return CreatedAtAction(
            nameof(GetToDoItem),
            new { id = todoItem.Id },
            ItemToDTO(todoItem));
    }
        // DELETE: api/TodoItems/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTodoItem(long id)
    {
        var todoItem = await _context.ToDoItems.FindAsync(id);
        if (todoItem == null)
        {
            return NotFound();
        }

        _context.ToDoItems.Remove(todoItem);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool TodoItemExists(long id)
    {
        return _context.ToDoItems.Any(e => e.Id == id);
    }

    private static ToDoItemDTO ItemToDTO(ToDoItem todoItem) =>
       new ToDoItemDTO
       {
           Id = todoItem.Id,
           Name = todoItem.Name,
           isComplete = todoItem.isComplete
       };
}
}
