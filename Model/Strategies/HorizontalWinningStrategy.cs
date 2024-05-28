namespace ConnectFour.Models.Strategies
{
    public class HorizontalWinningStrategy : IWinningStrategy
    {
        public bool CheckForWin(Board board, char playerSymbol)
        {
            for (int row = 0; row < Board.Rows; row++)
            {
                for (int col = 0; col < Board.Columns - 3; col++)
                {
                    if (board.GetCell(row, col) == playerSymbol &&
                        board.GetCell(row, col + 1) == playerSymbol &&
                        board.GetCell(row, col + 2) == playerSymbol &&
                        board.GetCell(row, col + 3) == playerSymbol)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
