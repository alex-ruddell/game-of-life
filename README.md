# Game Of Life
Conway's Game Of Life -- Cell Automation Simulation. One of many projects completed throughout an internship at MYOB in Auckland.

The program is a zero-player "game", with cell evolutions solely determined by the initial state of the game as set by the user.

## Rules  

The Game of Life evolves in a two-dimensional grid of square cells. Every cell interacts with its eight neighbors to determine its state on each game iteration - either "alive" or "dead". Cell state transmissions are determined by the following rules:

* Any live cell with fewer than two live neighbours dies, as if caused by underpopulation.  
* Any live cell with more than three live neighbours dies, as if by overcrowding.  
* Any live cell with two or three live neighbours lives on to the next generation.  
* Any dead cell with exactly three live neighbours becomes a live cell.  

## Solution

The solution prints these evolutions as "ticks" in the console, displaying the cells states as alive or dead using filled and unfilled squares respectively.

## References

* [John Conway Talks about the Game of Life Problem](https://youtu.be/FdMzngWchDk)  
* [Game of Life Rules](https://github.com/marcoemrich/game-of-life-rules/blob/master/gol_rules.pdf)  
* [Wikipedia on Conways Game Of Life](https://en.wikipedia.org/wiki/Conway%27s_Game_of_Life)  
