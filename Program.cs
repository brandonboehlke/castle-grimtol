using System;
using CastleGrimtol.Models;
using CastleGrimtol.Enums;

namespace CastleGrimtol
{
  public class Program
  {
    public static bool playing = true;
    public static Room CurrentRoom;
    public static void Go(Direction direction)
    {

      switch (direction)
      {
        case Direction.North:
          Console.WriteLine("Go North");
          break;
      }

      if (CurrentRoom.Exits.ContainsKey(direction))
      {
        CurrentRoom = CurrentRoom.Exits[direction];
        Look();
      }
      else
      {
        Console.WriteLine("Despite your best efforts you are unable to move to the " + direction);
      }
    }

    public static void Look()
    {
      Console.WriteLine(CurrentRoom.Name);
      Console.WriteLine(CurrentRoom.Description);
    }

    public static void Main(string[] args)
    {


      Console.WriteLine(@"Hello Brave Warrior our forces are failing and the enemy grows stronger everyday. I fear if we don't act now our people will be driven from their homes. These dark times have left us with one final course of action. We must cut the head off of the snake by assasinating the Dark Lord of Grimtol... Our sources have identified a small tunnel that leads into the rear of the castle.
Once you sneak through the tunnel you will need to find a way to disguise yourself and kill the Dark Lord. We don't know exactly how so you'll need to use your wit and cunning to think of something.
!");

      var hallway1 = new Room("A dark hallway", "You find yourself in a small hall there doesnt appear to be anything of interest here.");
      var barracks = new Room("Barracks", "You see a room with several sleeping guards, The room smells of sweaty men. The bed closest to you is empty and there are several uniforms tossed about.");

      hallway1.Exits.Add(Direction.North, barracks);
      barracks.Exits.Add(Direction.South, hallway1);

      CurrentRoom = hallway1;
      Look();
      while (playing)
      {
        Console.Write("What would you like to do: ");
        var decision = Console.ReadLine();
        var direction = ConvertStringToDirection(decision);

        if (decision == "q")
        {
          playing = false;
        }
        else
        {
          Go(direction);
        }
      }
    }

    private static Direction ConvertStringToDirection(string decision)
    {
      decision = decision.ToLower();
      switch (decision)
      {
        case "n":
        case "north":
          return Direction.North;
        case "s":
        case "south":
          return Direction.South;
      }
      return default(Direction);
    }
  }

  //   var permission = Permissions.Admin | Permissions.Editor | Permissions.User;
  //   if(permission.HasFlag(Permissions.Editor)){
  //       System.Console.WriteLine("Can Edit");
  //   }

  //   public enum Permissions
  //   {
  //     User = 1,
  //     Editor = 2,
  //     Admin = 4,
  //     SysAdmin = 8,
  //     SuperAdmin = 16
  //   }
}
