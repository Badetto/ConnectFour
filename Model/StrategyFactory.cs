using ConnectFour.Models.Strategies;

namespace ConnectFour.Model
{
    public class StrategyFactory
    {
        //Creational: Why is factory pattern used? A: Easier to extend, if we want to split the Diagonal Check for example
        //Based on an input it creates a specific Strategy instance
        public static IWinningStrategy CreateStrategy(string strategyType)
        {
            switch (strategyType)
            {
                case "Horizontal":
                    return new HorizontalWinningStrategy();
                case "Vertical":
                    return new VerticalWinningStrategy();
                case "Diagonal":
                    return new DiagonalWinningStrategy();
                default:
                    throw new ArgumentException("Invalid strategy type");
            }
        }
    }
}
