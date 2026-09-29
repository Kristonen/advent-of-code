interface ICommand
{
    Vec2 Start {get;}
    Vec2 End {get;}
    void Execute(bool[,] grid);
    void AdjustBrightness(int[,] birghtness);
}

class TurnOnCommand(Vec2 _start, Vec2 _end) : ICommand
{
    public Vec2 Start => _start;
    public Vec2 End => _end;

    public void Execute(bool[,] grid)
    {
        for(int x = _start.X; x <= _end.X; x++)
        {
            for(int y = _start.Y; y <= _end.Y; y++)
            {
                grid[x, y] = true;
            }
        }
    }

    public void AdjustBrightness(int[,] birghtness)
    {
        for(int x = _start.X; x <= _end.X; x++)
        {
            for(int y = _start.Y; y <= _end.Y; y++)
            {
                birghtness[x, y] += 1;
            }
        }
    }

    public override string ToString()
    {
        return $"Turn On Command\nStart: {_start.X} | {_start.Y}\nEnd: {_end.X} | {_end.Y}";
    }
}

class TurnOffCommand(Vec2 _start, Vec2 _end) : ICommand
{
    public Vec2 Start => _start;
    public Vec2 End => _end;

    public void Execute(bool[,] grid)
    {
        for(int x = _start.X; x <= _end.X; x++)
        {
            for(int y = _start.Y; y <= _end.Y; y++)
            {
                grid[x, y] = false;
            }
        }
    }
    public void AdjustBrightness(int[,] birghtness)
    {
        for(int x = _start.X; x <= _end.X; x++)
        {
            for(int y = _start.Y; y <= _end.Y; y++)
            {
                birghtness[x, y] = Math.Max(0, birghtness[x, y] - 1);
            }
        }
    }

    public override string ToString()
    {
        return $"Turn Off Command\nStart: {_start.X} | {_start.Y}\nEnd: {_end.X} | {_end.Y}";
    }
}

class ToggleCommand(Vec2 _start, Vec2 _end) : ICommand
{
    public Vec2 Start => _start;
    public Vec2 End => _end;

    public void Execute(bool[,] grid)
    {
        for(int x = _start.X; x <= _end.X; x++)
        {
            for(int y = _start.Y; y <= _end.Y; y++)
            {
                grid[x, y] = !grid[x, y];
            }
        }
    }
    public void AdjustBrightness(int[,] birghtness)
    {
        for(int x = _start.X; x <= _end.X; x++)
        {
            for(int y = _start.Y; y <= _end.Y; y++)
            {
                birghtness[x, y] += 2;
            }
        }
    }

    public override string ToString()
    {
        return $"Toggle Command\nStart: {_start.X} | {_start.Y}\nEnd: {_end.X} | {_end.Y}";
    }
}