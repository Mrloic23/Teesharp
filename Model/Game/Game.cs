using System;
using System.Collections.Generic;
using System.Linq;
using Teeko.Exceptions;
namespace Teeko.Model.Game
{
    public class Game
    {
        public bool IsOver => Board.IsOver();
        public Board Board { private set; get; }
        private readonly Dictionary<string, Player> Players;

        public Game()
        {
            Board = new();
            string name = "blue";
            Players.Add(name, new(name, State.blue));
            name = "red";
            Players.Add(name, new(name, State.red));
        }
        /// <summary>
        /// plays a turn
        /// </summary>
        /// <param name="source">source player</param>
        /// <param name="move"> move Struct</param>
        public void Play(Player source, Move move)
        {
            #region checks
            //Player check
            if (!Players.Values.Contains(source))
            {
                throw new InvalidPlayerException("invalid source");
            }
            //Coords checks
            if (move.SourceCell.Value.x is not >= 0 and <= 5 || move.SourceCell.Value.y is not >= 0 and <= 5)
            {
                throw new InvalidMoveException("Destination is off the board");
            }
            if (move.SourceCell.Value.x is not >= 0 and <= 5 || move.SourceCell.Value.y is not >= 0 and <= 5)
            {
                throw new InvalidMoveException("source is off the board");
            }
            //Destination State checks
            if (move.DestinationCell.State is not State.empty)
            {
                throw new InvalidMoveException("target cell is not empty");
            }
            if (move.SourceCell.Value.State != source.StateValue)
            {
                throw new InvalidMoveException("the source cell is not owned by this player");
            }
            //source to destination distance check
            if (move.DestinationCell.x - move.SourceCell.Value.x is not >= -1 and <= 1 || move.DestinationCell.y - move.SourceCell.Value.y is not >= -1 and <= 1)
            {
                throw new InvalidMoveException("distance between source and target is too great");
            }
            #endregion
            Board.Cells[move.DestinationCell.x][move.DestinationCell.y].SetState(source.StateValue);
            if (move.SourceCell.HasValue)
            {
                Board.Cells[move.SourceCell.Value.x][move.SourceCell.Value.y].SetState(source.StateValue);
            }
        }

    }
}