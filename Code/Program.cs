using Code.Modules;

int columns = 5;
int rows = 3;
int seed = 1234;
int generations = 5;

Grid grid = new Grid(columns, rows, seed);

Console.WriteLine("Grid initialized");
grid.Print();

for (int i = 0; i < generations; i++)
{
    grid.Next();
    Console.WriteLine($"\nGeneration {i + 1}");
    grid.Print();
}