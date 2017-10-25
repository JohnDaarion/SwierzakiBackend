using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace DatabaseConnectionProvider.Controllers
{
    [Route("api")]
    public class HelloWorldController : Controller
    {
        private readonly INoteRepository _noteRepository;


        public HelloWorldController(INoteRepository noteRepository)
        {
            _noteRepository = noteRepository;
        }

        [HttpGet]
        [Route("HelloWorld")]
        public string GetHelloWorld()
        {
            _noteRepository.AddNote(new Note() { Id = "1", Body = "Test note 1", 
                CreatedOn = DateTime.Now, UpdatedOn = DateTime.Now, UserId = 1 });

            foreach (var note in _noteRepository.GetAllNotes().Result.ToHashSet())
            {
                Console.Write(note.Id);
            }
            
            return "Hello World";
        }
    }
}
