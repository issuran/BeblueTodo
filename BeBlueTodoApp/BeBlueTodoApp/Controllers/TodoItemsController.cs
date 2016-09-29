using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using BeBlueTodoApp.Models;

namespace BeBlueTodoApp.Controllers
{
    public class TodoItemsController : ApiController
    {
        private BeBlueTodoAppContext db = new BeBlueTodoAppContext();

        // GET: api/TodoItems
        public IQueryable<TodoItemDTO> GetTodoItems()
        {
            var todoItems = from b in db.TodoItems
                            select new TodoItemDTO()
                            {
                                Id = b.Id,
                                Description = b.Description,
                                IsDone = b.IsDone,
                                PersonName = b.Person.Name,
                                PersonId = b.Person.Id
                            };
            return todoItems;
        }

        // GET: api/TodoItems/5
        [ResponseType(typeof(TodoItemDTO))]
        public async Task<IHttpActionResult> GetTodoItem(int id)
        {
            var todoItem = await db.TodoItems.Include(b => b.Person).Select(b => new TodoItemDTO()
            {
                Id = b.Id,
                Description = b.Description,
                IsDone = b.IsDone,
                PersonName = b.Person.Name,
                PersonId = b.Person.Id
            }).SingleOrDefaultAsync(b => b.Id == id);
            if (todoItem == null)
            {
                return NotFound();
            }
            return Ok(todoItem);
        }

        // PUT: api/TodoItems/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTodoItem(int id, TodoItem todoItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != todoItem.Id)
            {
                return BadRequest();
            }

            db.Entry(todoItem).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TodoItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/TodoItems
        [ResponseType(typeof(TodoItem))]
        public async Task<IHttpActionResult> PostTodoItem(TodoItem todoItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TodoItems.Add(todoItem);
            await db.SaveChangesAsync();

            db.Entry(todoItem).Reference(x => x.Person).Load();

            var dto = new TodoItemDTO()
            {
                Id = todoItem.Id,
                Description = todoItem.Description,
                IsDone = todoItem.IsDone,
                PersonName = todoItem.Person.Name,
                PersonId = todoItem.Person.Id
                
            };

            return CreatedAtRoute("DefaultApi", new { id = todoItem.Id }, dto);
        }

        // DELETE: api/TodoItems/5
        [ResponseType(typeof(TodoItem))]
        public async Task<IHttpActionResult> DeleteTodoItem(int id)
        {
            TodoItem todoItem = await db.TodoItems.FindAsync(id);
            if (todoItem == null)
            {
                return NotFound();
            }

            db.TodoItems.Remove(todoItem);
            await db.SaveChangesAsync();

            return Ok(todoItem);
        }



        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TodoItemExists(int id)
        {
            return db.TodoItems.Count(e => e.Id == id) > 0;
        }
    }
}