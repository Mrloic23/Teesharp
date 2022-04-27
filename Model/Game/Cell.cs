namespace Teeko.Model.Game
{
    public struct Cell
    {
        public readonly int x;
        public readonly int y;
        public State State { private set; get; }
        public Cell(int x,int y,State state)
        {
            this.y = y;
            this.x = x;
            State = state;
        }
        public void SetState(State state)
        {
            State = state;
        }
    }
    public enum State : short
    {
        empty,
        blue,
        red
    }
    
}