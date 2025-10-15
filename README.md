# Game of life

## Problem Description

This Kata is about calculating the next generation of Conway’s game of life, given any starting position. See http://en.wikipedia.org/wiki/Conway%27s_Game_of_Life for background.

You start with a two dimensional grid of cells, where each cell is either alive or dead. The grid is finite, and no life can exist off the edges. When calculating the next generation of the grid, follow these rules:

```
   1. Any live cell with fewer than two live neighbours dies, as if caused by underpopulation.
   2. Any live cell with more than three live neighbours dies, as if by overcrowding.
   3. Any live cell with two or three live neighbours lives on to the next generation.
   4. Any dead cell with exactly three live neighbours becomes a live cell.
```

You should write a program that starts with a random grid of cells, and will output a similar grid showing the next generation.

## Project structure
All the code is stored into the Code folder.

The code folder has a Program.cs that is the main of the project.
All the classes are stored into the folder `src/Modules`

### Grid
Contains all the logics of `Game of life`.
There is a constructor to initialize a Grid and 2 public methods that could be used:
- Print => Print into the console the grid status
- Next => Run a new generation

All other methods are private and used inside the Grid class.

### Cell
Contains the cell management.

A cell could be Alive (_isAlive = true) or Death (_isAlive = false) and could have some alive neighbors (_aliveNeighbors).

There are public 2 getters (to show outside the class the status of the private attributes _isAlive and _aliveNeighbors) and 2 public setters (to set the value of _isAlive and _aliveNeighbors).

