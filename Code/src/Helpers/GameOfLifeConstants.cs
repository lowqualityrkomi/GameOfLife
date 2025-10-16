namespace Code.Helpers;

public static class GameOfLifeConstants
{
    public const int MinimumNumberUnderPopulation = 2;
    public const int MaximumNumberOverCrowding = 3;
    public const int AliveNeighborsNeededToReborn = 3;
    public const bool AliveState = true;
    public const bool DeadState = false;
}