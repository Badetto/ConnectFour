namespace ConnectFour.Views
{
    public class View
    {
        public void DisplayBoard(string boardState)
        {
            Console.Clear();
            Console.WriteLine(boardState);
        }

        public void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
