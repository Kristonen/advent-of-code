using System.Diagnostics.CodeAnalysis;

string txt = File.ReadAllText("puzzle.txt");
string[] cmds = txt.Split('\n');
List<ICommand> listCmds = new();
CreateCommands(cmds, listCmds);
bool[,] grid = new bool[1000, 1000];
int[,] brightness = new int[1000, 1000];
int total_brightness = 0;
int counter = 1;
foreach(ICommand cmd in listCmds)
{
    Console.WriteLine($"Command {counter} wird ausgeführt!");
    cmd.Execute(grid);
    cmd.AdjustBrightness(brightness);
    counter++;
}
//PART ONE
counter = 0;
foreach(var on in grid)
{
    if(on) counter++;
}
//PART TWO
foreach(int single_brightness in brightness)
{
    total_brightness += single_brightness;
}
Console.WriteLine($"Es sind insgesamt {counter} Lichter an!");
Console.WriteLine($"Die Lichtstärke beträgt: {total_brightness}");

void CreateCommands(string[] cmds, List<ICommand> listCmds)
{
    for (int i = 0; i < cmds.Length; i++)
    {
        string[] arrayCmd = cmds[i].Split(' ');
        ICommand cmd;
        if(arrayCmd[0] == "turn")
        {
            Vec2 start = ToVec2(arrayCmd[2]);
            Vec2 end = ToVec2(arrayCmd[4]);
            cmd = arrayCmd[1] == "on" ? new TurnOnCommand(start, end) : new TurnOffCommand(start, end);
        }
        else
        {
            Vec2 start = ToVec2(arrayCmd[1]);
            Vec2 end = ToVec2(arrayCmd[3]);
            cmd = new ToggleCommand(start, end);
        }
        listCmds.Add(cmd);
    }
}

Vec2 ToVec2(string txt)
{
    string[] numbers = txt.Split(',');
    int x = Convert.ToInt32(numbers[0]);
    int y = Convert.ToInt32(numbers[1]);
    return new(x, y);
}


struct Vec2(int _x, int _y) : IEquatable<Vec2>
{
    public int X {get => _x; set => _x = value;}
    public int Y {get => _y; set => _y = value;}

    public bool Equals(Vec2 other) => X == other.X && Y == other.Y;
    public override bool Equals(object? obj) => obj is Vec2 && Equals(obj);
    public override int GetHashCode() => HashCode.Combine(X, Y);
}
