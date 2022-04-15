using Teeko.Exceptions;

namespace Teeko.Model.Game
{
    public class Player
    {
        public string Name { init; get; }
        public State StateValue { init; get; }
        public Cell[] Cells { private set; get; }
        public Player(string name, State stateValue)
        {
            Name = name;
            StateValue = stateValue;
        }
        public void SetCell(Cell Destination)
        {
            if (Cells.Length >= 4)
            {
                throw new InvalidMoveException("Player already has 4 cells");
            }
            if (Destination.x > 5 || Destination.y > 5)
            {
                throw new InvalidMoveException("invalid coordinates");
            }

        }
    }
}