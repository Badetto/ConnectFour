using ConnectFour.Models;
using ConnectFour.Views;

namespace ConnectFour.Controllers
{
    public class Controller
    {
        //Structural: Facade, Controller acts like a simplified interface to a set of classes: View and Service, which also does
        //the same with Board and Player
        //Easier to read the code.
        private Service service;
        private View view;

        public Controller()
        {
            service = Service.GetInstance();
            view = new View();
        }

        public void StartGame()
        {
            service.InitializeGame();

            while (!service.IsGameOver())
            {
                view.DisplayBoard(service.GetBoardState());
                view.DisplayMessage($"Player {service.CurrentPlayer.Symbol}'s turn. Enter column to place your disc (1-7): ");

                bool isValidInput = int.TryParse(Console.ReadLine(), out int column);
                if (isValidInput && column >= 1 && column <= Board.Columns)
                {
                    column -= 1;
                    var (success, message) = service.MakeMove(column);
                    if (!success)
                    {
                        view.DisplayMessage(message);
                        Console.ReadKey();
                    }
                }
                else
                {
                    view.DisplayMessage("Please enter a valid integer between 1 and 7. Press enter to retry.");
                    Console.ReadKey();
                }
            }
            view.DisplayBoard(service.GetBoardState());
            view.DisplayMessage(service.GetGameResult());
            view.DisplayMessage("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
