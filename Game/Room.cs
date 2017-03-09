using System.Collections.Generic;
using CastleGrimtol.Enums;

namespace CastleGrimtol.Models
{
  public class Room
  {

    public string Name {get; protected set;}
    public string Description { get; protected set; }
    public Dictionary<Direction, Room> Exits = new Dictionary<Direction, Room>();

    public Room(string name, string description)
    {
      Name = name;
      Description = description;
    }


  }
}