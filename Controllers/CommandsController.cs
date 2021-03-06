using System.Collections.Generic;
using AutoMapper;
using Commander.Data;
using Commander.Dtos;
using Commander.Models;
using Microsoft.AspNetCore.Mvc;

namespace Commander.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class CommandsController : ControllerBase
  {
    private readonly ICommanderRepo _repository;
    private readonly IMapper _mapper;

    public CommandsController(ICommanderRepo repository,IMapper mapper)
    {
      _repository = repository;
       _mapper = mapper;
    }


    // private readonly MockCommanderRepo _repository = new MockCommanderRepo();
    //Get api/commands
    [HttpGet]
    public ActionResult<IEnumerator<Command>> GetAllCommands()
    {
      var commandItems = _repository.GetAppCommands();

     // return Ok(commandItems);
      return Ok(_mapper.Map<IEnumerable<CommandReadDto>>(commandItems));
    }

    //Get api/commands/{id}
    [HttpGet("{id}")]
    public ActionResult<CommandReadDto> GetCommandById(int id)
    {
      var commandItem = _repository.GetCommandById(id);
      if(commandItem != null)
      {
        // return Ok(commandItems);
        return Ok(_mapper.Map<CommandReadDto>(commandItem));
      }
      return NotFound();
    }

    //Post api/commands
    [HttpPost]
    public ActionResult<CommandReadDto> CreateCommand(CommandCreateDto commandCreateDto)
    {
      var commandModel = _mapper.Map<Command>(commandCreateDto);
      _repository.CreateCommand(commandModel);
      _repository.SaveChanges();


      return Ok(commandModel);
    }

  }
}