using ConnectFour.Controllers;

class Program
{
    static void Main()
    {
        //Architectural Pattern: Model View Controller Service.
        //Model handles game data.
        //View handles user "interface" (every Console.WriteLine).
        //Controller processes user input.
        //Service handles game logic (state).
        Controller controller = new Controller();
        controller.StartGame();
    }
}
