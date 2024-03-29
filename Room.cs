using System.ComponentModel;
using System.Dynamic;
using System.Runtime.CompilerServices;

class Room
{
    public (int x, int y) Point {get;set;} // position inside the dungeon
    
    // Rooms at the exits
    public Room? North {get;set;}
    public Room? South {get;set;}
    public Room? East {get;set;}
    public Room? West {get;set;}

    // for drawing purposes, use a different color for active room, visited rooms and unvisited rooms
    public bool VisitedRoom {get;set;}
    public bool ActiveRoom {get;set;}

    // What is in the room? 
    public bool HasMonster {get;set;}
    public bool HasMaelstrom {get;set;}
    public bool HasPit {get;set;}
    public bool HasTreasure{get;set;}
    // is the fountain here
    public bool HasFountain{get;set;}
    public bool HasExit{get;set;}

    // constructor for a typical room
    public Room (int x, int y, bool hasFountain)
    {
        ActiveRoom = false;
        VisitedRoom = false;
        Point = (x,y);
        North = null;
        South = null;
        East = null;
        West = null;
        Random rand = new Random();
        HasMonster = false;
        HasMaelstrom = false;
        HasPit = false;
        HasTreasure = false;
        if(hasFountain)
        {
            HasFountain = true;
        }
        // chances of different things being in the room
        else
        {
            double odds = rand.NextDouble();
            if (odds > .8)
                HasMonster = true;
            odds = rand.NextDouble();
            if (odds < .2)
                HasMaelstrom = true;
            odds = rand.NextDouble();
            if (odds > .6)
                HasTreasure = true;
            odds = rand.NextDouble();
            if (odds > .9)
                HasPit = true;
        }
    }
    
}