namespace ConnectFour.Models.Strategies
{
    public interface IWinningStrategy
    {
        //Behavioral: Strategy: All winning strategies are defined by this interface, which all implement.
        //Winning strategies could be used interchangeably.
        bool CheckForWin(Board board, char playerSymbol);
    }
}
