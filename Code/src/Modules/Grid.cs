using Code.Helpers;

namespace Code.Modules;

public class Grid
{
    private Cell[,] _cells;

    private int _columns;
    private int _rows;
    
    public Grid(int columns, int rows, int seed)
    {
        // Check if the provided columns and rows are valid
        if(rows <= 0 || columns <= 0)
            throw new ArgumentException("Grid must have at least one row and column");
        
        // Set columns and rows
        _columns = columns;
        _rows = rows;
    
        // Initialize the grid by the provided seed
        _cells = GenerateMatrix(seed);
    }
    
    // Method to print the matrix in console
    public void Print()
    {
        for (int row = 0; row < _rows; row++)
        {
            Console.Write("|");
            for (int col = 0; col < _columns; col++)
            {
                int toPrint = _cells[row, col].IsAlive ? 1 : 0;
                Console.Write($" {toPrint} |");
            }
            Console.Write("\n");
        }
    }

    // Method to run a new generation
    public void Next()
    {
        // Create a temp matrix to register the changes
        Cell[,] nextGeneration = new Cell[_rows, _columns];
        
        // Start checking
        for (int row = 0; row < _rows; row++)
        {
            for (int col = 0; col < _columns; col++)
            {
                // Register how many alive neighbors has the current cell
                _cells[row,col].SetAliveNeighbors(CountAliveNeighbors(row, col));
                
                // Create cell for convenience
                Cell currentCell = _cells[row, col];
                
                // Initialize the temp cell using the current value of the main grid
                nextGeneration[row, col] = new Cell(currentCell.IsAlive);
                
                // Check if the cell is alive and should die
                if(currentCell.IsAlive && currentCell.ShouldDie())
                    nextGeneration[row, col].SetIsAlive(GameOfLifeConstants.DeadState);
                
                // Check if the cell is death and should reborn
                else if(!currentCell.IsAlive && currentCell.ShouldReborn())
                    nextGeneration[row, col].SetIsAlive(GameOfLifeConstants.AliveState);
            }
        }
        
        _cells = nextGeneration;
    }

    // Method to count and return the current alive neighbors of a cell
    private int CountAliveNeighbors(int row, int column)
    {
        // Initialize the counter
        int aliveNeighbors = 0;
        
        // Create a double loop to check all the directions
        // Directions = TopLeft, Top, Top right, Right, Bottom right, Bottom, Bottom left, Left
        for (int neighborRow = -1; neighborRow <= 1; neighborRow++)
        {
            for (int neighborCol = -1; neighborCol <= 1; neighborCol++)
            {
                // Skip if it's checking itself
                if (neighborRow == 0 && neighborCol == 0)
                    continue;
                
                // Create current coordinates to check
                int rowToCheck = neighborRow + row;
                int colToCheck = neighborCol + column;
                
                // Skip if it isn't a valid direction
                // The grid is finite, and no life can exist off the edges
                if (rowToCheck == -1 || rowToCheck == _rows || colToCheck == -1 || colToCheck == _columns)
                    continue;
                
                // Check if the cell in the current direction is alive and count it
                if(_cells[rowToCheck, colToCheck].IsAlive)
                    aliveNeighbors++;
                
            }
        }
        
        return aliveNeighbors;
    }

    // Method to generate the matrix on init
    private Cell[,] GenerateMatrix(int seed)
    {
        // Use the seed to generate a pseudo-random matrix
        Random random = new Random(seed);
        // Initialize the grid to return
        Cell[,] newGrid = new Cell[_rows, _columns];

        for (int row = 0; row < _rows; row++)
        {
            for (int col = 0; col < _columns; col++)
            {
                // Generate a pseudo-random value for the current cell
                newGrid[row, col] = new Cell(random.Next(0, 2) == 1);
            }
        }

        return newGrid;
    }
}