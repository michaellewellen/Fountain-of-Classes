using System.Security.Cryptography.X509Certificates;

static class Draw
{
    static public void DrawRoom(Room room)
    {
        // upper left corner
        Console.SetCursorPosition(room.Point.x, room.Point.y);
        string ulc = "";
        if (room.North == null && room.West == null)
            ulc = "╔";
        else if (room.North == null && room.West != null)
            ulc = "╦";
        else if (room.North !=null && room.West == null)
            ulc = "╠";
        else 
            ulc = "╬";
        // upper right corner
        string urc = "";
        if (room.North == null && room.East == null)
            urc = "╗";
        else if (room.North == null && room.East != null)
            urc = "╦";
        else if (room.North !=null && room.East == null)
            urc = "╣";
        else 
            urc = "╬";
        // Lower left corner
        string llc = "";
        if (room.South == null && room.West == null)
            llc = "╚";
        else if (room.South == null && room.West != null)
            llc = "╩";
        else if (room.South !=null && room.West == null)
            llc = "╠";
        else 
            llc = "╬";
        // Lower right corner
        string lrc = "";
        if (room.South == null && room.East == null)
            lrc = "╝";
        else if (room.South == null && room.East != null)
            lrc = "╩";
        else if (room.South !=null && room.East == null)
            lrc = "╣";
        else 
            lrc = "╬";
        
        // doors (nd = north door, sd = south door, ed = east door, wd = west door)
        string nd = "   ";
        string sd = "   ";
        string wd = " ";
        string ed = " ";
        if (room.North == null)
            nd = "═══";
        if (room.South == null)
            sd = "═══";
        if (room.East == null)
            ed = "║";
        if (room.West == null)
            wd = "║";
        // pick a color
        if(room.ActiveRoom == true)
            Console.ForegroundColor = ConsoleColor.White;
        else if (room.VisitedRoom)
            Console.ForegroundColor = ConsoleColor.Green;
        else
            Console.ForegroundColor = ConsoleColor.DarkRed;


        Console.SetCursorPosition(room.Point.x*10,room.Point.y*4);
        Console.Write($"{ulc}═══{nd}═══{urc}");
        Console.SetCursorPosition(room.Point.x*10,room.Point.y*4 + 1);
        Console.Write("║         ║");
        Console.SetCursorPosition(room.Point.x*10,room.Point.y*4 + 2);
        Console.Write($"{wd}         {ed}");
        Console.SetCursorPosition(room.Point.x*10,room.Point.y*4 + 3);
        Console.Write("║         ║");
        Console.SetCursorPosition(room.Point.x*10,room.Point.y*4 + 4);
        Console.Write($"{llc}═══{sd}═══{lrc}");

        Console.ForegroundColor = ConsoleColor.White;
    }
}