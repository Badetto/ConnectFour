namespace ConnectFour.Models
{
    public class MoveCommand
    {
        //Behavioral: Command Patter into an object that containsall the relevant information.
        //Execute method triggers the action.
        //It could be useful in the future if we want to keep track of the moves history.
        private Board board;
        private int column;
        private char symbol;

        public MoveCommand(Board board, int column, char symbol)
        {
            this.board = board;
            this.column = column;
            this.symbol = symbol;
        }

        public bool Execute()
        {
            return board.PlacePiece(column, symbol);
        }
    }
}
