using Code.Modules;

int columns = 5;
int rows = 3;

Grid grid = new Grid(columns, rows, 1234);

Console.WriteLine("Grid initialized");
grid.Print();

for (int i = 0; i < 5; i++)
{
    grid.Next();
    Console.WriteLine($"\nMove {i + 1}");
    grid.Print();
}