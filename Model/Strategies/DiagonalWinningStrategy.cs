namespace ConnectFour.Models.Strategies
{
    public class DiagonalWinningStrategy : IWinningStrategy
    {
        public bool CheckForWin(Board board, char playerSymbol)
        {
            for (int row = 0; row < Board.Rows - 3; row++)
            {
                for (int col = 0; col < Board.Columns - 3; col++)
                {
                    if (board.GetCell(row, col) == playerSymbol &&
                        board.GetCell(row + 1, col + 1) == playerSymbol &&
                        board.GetCell(row + 2, col + 2) == playerSymbol &&
                        board.GetCell(row + 3, col + 3) == playerSymbol)
                    {
                        return true;
                    }
                }
            }

            for (int row = 3; row < Board.Rows; row++)
            {
                for (int col = 0; col < Board.Columns - 3; col++)
                {
                    if (board.GetCell(row, col) == playerSymbol &&
                        board.GetCell(row - 1, col + 1) == playerSymbol &&
                        board.GetCell(row - 2, col + 2) == playerSymbol &&
                        board.GetCell(row - 3, col + 3) == playerSymbol)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
