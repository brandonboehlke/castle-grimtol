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
                     case Direction.South:
                    Console.WriteLine("Go South");
                    break;
                     case Direction.East:
                    Console.WriteLine("Go East");
                    break;
                     case Direction.West:
                    Console.WriteLine("Go West");
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


            Console.WriteLine(@"Hello, Brave Warrior! our forces are failing and the enemy grows stronger everyday. I fear if we don't act now our people will be driven from their homes. These dark times have left us with one final course of action. We must cut the head off of the snake by assassinating the Dark Lord of Grimtol... Our sources have identified a small tunnel that leads into the rear of the castle.
Once you sneak through the tunnel, you will need to find a way to disguise yourself and kill the Dark Lord. We don't know exactly how so you'll need to use your wit and cunning to think of something.
!");

            var hallway1 = new Room("A dark hallway", "You find yourself in a small hall.  There doesn't appear to be anything of interest here. You see 3 paths before you: go north to the barracks, east to the courtyard, or south to the captain's quarters.");
            var barracks = new Room("Barracks", "You see a room with several sleeping guards.  You smell pungent body odors emanating from the sweaty guards. The bed closest to you is empty and there are several uniforms tossed about.");
            var captain = new Room("Captain's Quarters", "As you approach the captain's quarters, you swallow hard and notice your lips are dry; Stepping into the room, you see a few small tables and maps of the countryside sprawled out.  What now?  Shall you go east to the hallway south of the courtyard or back north towards the barracks?");
            var hallway2 = new Room("Southern Hallway", "Nothing here but two options: go north to the courtyard or east to the guard tower.");
            var courtyard = new Room("The Castle Courtyard", "You step into the large castle courtyard. There is a flowing fountain in the middle of the grounds and a few guards patrolling the area.  From here you can go north, west, or south.  Choose Wisely!");
            var hallway3 = new Room("Northern Hallway", "As you exit the courtyard, you enter yet another hallway and notice there are two directions you can head in: north to the throne room, or east to the squire's tower.");
            var throne = new Room("Throne Room", "As you enter the throne room, you gaze upon its vastness.  In the distance you notice the dark lord of the si...er ... The Dark Lord sitting on his throne gazing at you with his red glowing eyes.  It sends chills down your spine.  You can stay and fight ... or turn around, head back south, and run away!  I suggest running!");
            var squire = new Room("Squire Tower", "As you finish climbing the stairs to the squire tower, you see a messenger nestled in his bed. His messenger overcoat is hanging from his bed post.  You also notice another room to the north. ");
            var council = new Room("The Royal Council Room", "This is where the Dark Lord and his council of minions plot to take over the world ... again!  There's no one here currently so you might as well turn back south to the squire tower!");
            var guard = new Room("Guard Tower", "Pushing open the door of the guard room you look around and notice the room is empty, There are a few small tools in the corner and a chair propped against the wall near the door that likely leads to the dungeon. ");
            var dungeon = new Room("The Castle Dungeon", "As you descend the stairs to the dungeon you notice a harsh chill in the air. Landing at the base of the stairs, you see what the remains of a previous prisoner. There doesn't appear to be anything else of interest here. You should head south back to the guard tower");

            hallway1.Exits.Add(Direction.North, barracks);
            barracks.Exits.Add(Direction.South, hallway1);
            hallway1.Exits.Add(Direction.South, captain);
            captain.Exits.Add(Direction.North, hallway1);
            captain.Exits.Add(Direction.East, hallway2);
            hallway2.Exits.Add(Direction.West, captain);
            hallway2.Exits.Add(Direction.North, courtyard);
            courtyard.Exits.Add(Direction.South, hallway2);
            hallway2.Exits.Add(Direction.East, guard);
            guard.Exits.Add(Direction.West, hallway2);
            guard.Exits.Add(Direction.North, dungeon);
            dungeon.Exits.Add(Direction.South, guard);
            hallway1.Exits.Add(Direction.East, courtyard);
            courtyard.Exits.Add(Direction.West, hallway1);
            courtyard.Exits.Add(Direction.North, hallway3);
            hallway3.Exits.Add(Direction.South, courtyard);
            hallway3.Exits.Add(Direction.North, throne);
            throne.Exits.Add(Direction.South, hallway3);
            hallway3.Exits.Add(Direction.East, squire);
            squire.Exits.Add(Direction.West, hallway3);
            squire.Exits.Add(Direction.North, council);
            council.Exits.Add(Direction.South, squire);

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
                case "e":
                case "east":
                    return Direction.East;
                case "w":
                case "west":
                    return Direction.West;
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
