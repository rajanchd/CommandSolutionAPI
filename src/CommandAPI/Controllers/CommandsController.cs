using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

using CommandAPI.Data;
using CommandAPI.Models;

namespace CommandAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommandsController : ControllerBase
    {


        // We create a private read-only field _repository that will  be assigned the injected 
        // MockCommandAPIRepo object in our constructor and used throughout the rest of our code.
        private readonly ICommandAPIRepo _repository;

        public CommandsController(ICommandAPIRepo repository)
        {
            _repository = repository;
        }

        // [HttpGet]
        // public ActionResult<IEnumerable<string>> Get()
        // {
        //     return new string[] { "This", "is", "hard", "coded." };
        // }


        /*What is IEnumerable in C#?
        IEnumerable in C# is an interface that defines one method, GetEnumerator which returns an IEnumerator interface. This allows readonly access to a collection then a collection that implements IEnumerable can be used with a for-each statement.

        Key Points
        IEnumerable interface contains the System.Collections.Generic namespace.
        IEnumerable interface is a generic interface which allows looping over generic or non-generic lists.
        IEnumerable interface also works with linq query expression.
        IEnumerable interface Returns an enumerator that iterates through the collection.

        Ref.: https://www.c-sharpcorner.com/UploadFile/0c1bb2/ienumerable-interface-in-C-Sharp/ */

        [HttpGet]
        public ActionResult<IEnumerable<Command>> GetAllCommands()
        {
            var commandItems = _repository.GetAllCmmands();
            return Ok(commandItems);
        }

        [HttpGet("{id}")]
        public ActionResult<Command> GetCommandById(int id)
        {

            // if (id == null)
            // throw new ArgumentNullException("id");
            // else if (String.Equals(id, ""))
            // throw new  AgrumentException("Empty values are not allowed.", "value");

            var commandItem = _repository.GetCommandById(id);
            if (commandItem == null)
                return NotFound();
            return Ok(commandItem);
        }
    }
}