using System.Security.Cryptography.X509Certificates;

Console.Clear();
Console.WriteLine(@"Welcome to the Fountain of Class. 
How hard do you want your game to be?
1. 3x3 grid (easy)
2. 4x4 grid (regular)
3. 5x5 grid (hard)
4. 6x6 grid (very hard)
");
int difficulty = (Convert.ToInt32(Console.ReadLine()));
int GridSize;
switch (difficulty)
{
    case 1: GridSize = 3; break;
    case 2: GridSize = 4; break;
    case 3: GridSize = 5; break;
    case 4: GridSize = 6; break;
    default: GridSize = 4;break;
}



Room[,] Grid = new Room[GridSize,GridSize];
// make blank room, then set n/s/e/w
for (int i = 0; i<GridSize; i++)
    for (int j = 0; j<GridSize; j++)
        Grid[i,j] = new Room(i,j,false);

// Set North/South/East/West
for (int i = 0; i<GridSize; i++)
{
    for(int j = 0; j<GridSize; j++)
    {
        if (j != 0)
            Grid[j,i].West = Grid[j-1,i];
        else
            Grid[j,i].West = null;
        if (j != GridSize-1)
            Grid[j,i].East = Grid[j+1,i];
        else 
            Grid[j,i].East = null;
        if (i != 0)
            Grid[j,i].North = Grid[j,i-1];
        else    
            Grid[j,i].North = null;
        if (i != GridSize-1)
            Grid[j,i].South = Grid[j,i+1];
        else
            Grid[j,i].South = null;
    }
}

Grid[0,0].HasExit = true;
Grid[0,0].ActiveRoom = true;
Room activeRoom = Grid[0,0];


// Simulate moving south
activeRoom.ActiveRoom = false;
activeRoom.VisitedRoom = true;
activeRoom = activeRoom.South;
activeRoom.ActiveRoom = true;


foreach (Room room in Grid)
    Draw.DrawRoom(room);
Draw.DrawRoom(activeRoom);

Console.SetCursorPosition(0,25);