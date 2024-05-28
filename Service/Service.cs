using ConnectFour.Models;

public class Service
{
    //Creational: Manages the state of the game -> Singleton used to make sure there is only one instance of Service

    private static Service? _instance = null;
    private static readonly object _lock = new object();

    private Board board;
    private Player[] players;
    private int currentPlayerIndex;

    private Service()
    {
        board = new Board();
        players = new Player[] { new Player('X'), new Player('O') };
        currentPlayerIndex = 0;
    }

    public static Service GetInstance()
    {
        lock (_lock)
        {
            if (_instance == null)
            {
                _instance = new Service();
            }
            return _instance;
        }
    }

    public void InitializeGame()
    {
        board.Clear();
        currentPlayerIndex = 0;
    }

    public (bool success, string message) MakeMove(int column)
    {
        if (board.IsColumnFull(column))
        {
            return (false, "Invalid move, the column is full. Press enter to retry.");
        }

        MoveCommand move = new MoveCommand(board, column, CurrentPlayer.Symbol);
        if (move.Execute())
        {
            if (board.CheckForWin(CurrentPlayer.Symbol))
            {
                return (true, "");
            }
            currentPlayerIndex = (currentPlayerIndex + 1) % 2;
            return (true, "");
        }
        return (false, "Invalid move, try again. Press enter to retry.");
    }

    public bool IsGameOver()
    {
        return board.IsFull() || board.CheckForWin(players[0].Symbol) || board.CheckForWin(players[1].Symbol);
    }

    public string GetBoardState()
    {
        return board.ToString();
    }
        
    public string GetGameResult()
    {
        if (board.CheckForWin(players[0].Symbol))
            return $"Player {players[0].Symbol} wins!";
        if (board.CheckForWin(players[1].Symbol))
            return $"Player {players[1].Symbol} wins!";
        if (board.IsFull())
            return "It's a draw!";
        return "";
    }

    public Player CurrentPlayer => players[currentPlayerIndex];
}
