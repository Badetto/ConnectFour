namespace ConnectFour.Models.Strategies
{
    public class VerticalWinningStrategy : IWinningStrategy
    {
        public bool CheckForWin(Board board, char playerSymbol)
        {
            for (int col = 0; col < Board.Columns; col++)
            {
                for (int row = 0; row < Board.Rows - 3; row++)
                {
                    if (board.GetCell(row, col) == playerSymbol &&
                        board.GetCell(row + 1, col) == playerSymbol &&
                        board.GetCell(row + 2, col) == playerSymbol &&
                        board.GetCell(row + 3, col) == playerSymbol)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
