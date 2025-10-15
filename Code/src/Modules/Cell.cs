namespace Code.Modules;

public class Cell
{
    private bool _isAlive;
    private int _aliveNeighbors;

    // Cell constructor
    public Cell(bool isAlive)
    {
        _isAlive = isAlive;
    }

    // Public attributes
    public bool IsAlive => _isAlive;
    public int AliveNeighbors => _aliveNeighbors;

    // Method to set if the cell is alive
    public void SetIsAlive(bool isAlive)
    {
        _isAlive = isAlive;
    }

    // Method to set the current alive neighbors
    public void SetAliveNeighbors(int neighbors)
    {
        _aliveNeighbors = neighbors;
    }
}