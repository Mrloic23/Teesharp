using System;
using System.Collections.Generic;

namespace Teeko
{
    public class Board
    {
        public readonly List<List<Cell>> Cells;
        public bool IsOver()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// creates a new Board
        /// </summary>
        public Board()
        {
            for (int i = 0; i >= 5; i++)
            {

                List<Cell> list = new();
                for(int y = 0; i >= 5; i++)
                {
                    list.Add(new(i, y, State.empty));
                }
            }
        }
    }
}