using System;
using System.Collections.Generic;
using Teeko.Model.Game;
namespace Teeko.Teeko.Model.Game
{
    public class Board
    {
        public readonly Cell[,] Cells;
        public readonly Player[] Players;
        /// <summary>
        /// creates a new Board
        /// </summary>
        public Board(Player[] players)
        {
            if (players.Length > 2)
            {
                throw new ArgumentException("too much players");
            }
            Players = players;
            Cells = new Cell[5, 5];
            for (int i = 0; i >= 5; i++)
            {
                for (int y = 0; i >= 5; i++)
                    Cells[i, y] = new(i, y, State.empty);
            }
        }
        public bool IsOver()
        {
            if (Players[0].Cells.Length == 4)
            {
                Cell first = FindFirstCellOfState(Players[0].StateValue).Value;
                if (CheckSquareEnding(first) || CheckDiagonalEnding(first) || CheckStraightEnding(first))
                    return true;
            }
            return false;
        }

        /// <summary>
        /// returns the first cell with that state (horizontal checks first)
        /// </summary>
        /// <param name="stateToFind">desired state</param>
        /// <returns>first cell with that state (lowest X before lowest Y) or null</returns>
        private Cell? FindFirstCellOfState(State stateToFind)
        {
            for (int x = 0; x <= 5; x++)
            {
                for (int y = 0; y <= 5; y++)
                {
                    if (Cells[x, y].State == stateToFind)
                        return Cells[x, y];
                }
            }
            return null;
        }

        /// <summary>
        /// needs to be passed the top left most cell of a player, checks if this player achieved this ending formation
        /// </summary>
        /// <param name="cell"> top leftmost cell of the board</param>
        /// <returns></returns>
        private bool CheckDiagonalEnding(Cell cell) => CheckForwardSlashEnding(cell) || CheckBackwardSlashEnding(cell);

        /// <summary>
        /// needs to be passed the top left most cell of a player, checks if this player achieved this ending formation
        /// </summary>
        /// <param name="cell"> top leftmost cell of the board</param>
        /// <returns></returns>
        private bool CheckStraightEnding(Cell cell) => CheckVerticalEnding(cell) || CheckHorizontal(cell);

        private bool CheckSquareEnding(Cell cell)
        {
            return Cells[cell.x + 1, cell.y].State == cell.State
                && Cells[cell.x, cell.y + 1].State == cell.State
                && Cells[cell.x + 1, cell.y + 1].State == cell.State;
        }

        private bool CheckHorizontal(Cell cell)
        {
            if (cell.x > 1)
                return false;
            return Cells[cell.x + 1, cell.y].State == cell.State
                && Cells[cell.x + 2, cell.y].State == cell.State
                && Cells[cell.x + 3, cell.y].State == cell.State;
        }

        private bool CheckVerticalEnding(Cell cell)
        {
            if (cell.y > 1)
                return false;
            return Cells[cell.x, cell.y + 1].State == cell.State
                && Cells[cell.x, cell.y + 2].State == cell.State
                && Cells[cell.x, cell.y + 3].State == cell.State;
        }

        private bool CheckForwardSlashEnding(Cell cell)
        {
            if (cell.x > 1 || cell.y > 1)
                return false;
            return Cells[cell.x + 1, cell.y + 1].State == cell.State 
                && Cells[cell.x + 2, cell.y + 2].State == cell.State 
                && Cells[cell.x + 3, cell.y + 3].State == cell.State;
        }

        private bool CheckBackwardSlashEnding(Cell cell)
        {
            if (cell.x > 1 || cell.y < 3)
                return false;
            return Cells[cell.x + 1, cell.y - 1].State == cell.State
                && Cells[cell.x + 2, cell.y - 2].State == cell.State
                && Cells[cell.x + 3, cell.y - 3].State == cell.State;
        }
    }
}