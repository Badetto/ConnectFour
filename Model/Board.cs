using ConnectFour.Model;
using ConnectFour.Models.Strategies;
using System.Text;

namespace ConnectFour.Models
{
    public class Board
    {
        public const int Rows = 6;
        public const int Columns = 7;
        private char[,] grid = new char[Rows, Columns];
        private List<IWinningStrategy> winStrategies;
        public Board()
        {
            Clear();
            winStrategies = new List<IWinningStrategy>
            {
                StrategyFactory.CreateStrategy("Horizontal"),
                StrategyFactory.CreateStrategy("Vertical"),
                StrategyFactory.CreateStrategy("Diagonal")
            };
        }

        public void Clear()
        {
            for (int row = 0; row < Rows; row++)
                for (int col = 0; col < Columns; col++)
                    grid[row, col] = '-';
        }

        public bool PlacePiece(int column, char symbol)
        {
            for (int row = Rows - 1; row >= 0; row--)
            {
                if (grid[row, column] == '-')
                {
                    grid[row, column] = symbol;
                    return true;
                }
            }
            return false;
        }

        public bool IsFull()
        {
            for (int col = 0; col < Columns; col++)
            {
                if (grid[0, col] == '-')
                    return false;
            }
            return true;
        }

        public bool CheckForWin(char symbol)
        {
            foreach (var strategy in winStrategies)
            {
                if (strategy.CheckForWin(this, symbol))
                {
                    return true;
                }
            }
            return false;
        }

        public bool IsColumnFull(int column)
        {
            return grid[0, column] != '-';
        }

        public char GetCell(int row, int column)
        {
            return grid[row, column];
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            for (int col = 1; col <= Columns; col++)
            {
                builder.Append(col);
                builder.Append(' ');
            }
            builder.AppendLine();
            for (int row = 0; row < Rows; row++)
            {
                for (int col = 0; col < Columns; col++)
                {
                    builder.Append(grid[row, col]);
                    builder.Append(' ');
                }
                builder.AppendLine();
            }
            return builder.ToString();
        }
    }
}
