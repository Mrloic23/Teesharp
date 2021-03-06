namespace Teeko.Model.Game
{
    public struct Move
    {
        public Cell? SourceCell { init; get; }
        public Cell DestinationCell { init; get; }

        public Move(Cell? sourceCell, Cell destinationCell)
        {
            SourceCell = sourceCell;
            DestinationCell = destinationCell;
        }
    }
}
