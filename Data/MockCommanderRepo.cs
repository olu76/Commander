using System.Collections.Generic;
using Commander.Models;

namespace Commander.Data
{
  public class MockCommanderRepo : ICommanderRepo
  {
    public void CreateCommand(Command cmd)
    {
      throw new System.NotImplementedException();
    }

    public IEnumerable<Command> GetAppCommands()
    {
      var commands = new List<Command>
    {
      new Command{Id=0, HowTO="Boil an egg", Line="Boil water", Platform="Kettle & Pan"},
      new Command{Id=1, HowTO="Cut bread", Line="Get a knife", Platform="Knife & shopping board"},
      new Command{Id=2, HowTO="Make a cup of tea", Line="Place teabag in cup", Platform="Kettle & cup"},

    };
      return commands;
    }


    public Command GetCommandById(int id)
    {
      return new Command { Id = 0, HowTO = "Boil an egg", Line = "Boil water", Platform = "Kettle & Pan" };
    }

    public bool SaveChanges()
    {
      throw new System.NotImplementedException();
    }
  }
}


