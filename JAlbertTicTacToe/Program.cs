using System;
using System.Runtime.CompilerServices;

int[] ticTacToeBoard = new int[9];

for(int i = 0; i < 9; i++)
{
    ticTacToeBoard[i] = 0;
}

int userTurn = -1;
int computerTurn = -1;
Random random = new Random();

while (checkForAWinner() == 0)
{

    {
        //don't allow the human to cheat and overwrite the computer's choices

        while (userTurn == -1 || ticTacToeBoard[userTurn] != 0)
        {
            Console.WriteLine("Please enter from 0 to 8");
            userTurn = int.Parse(Console.ReadLine());
            Console.WriteLine($"You typed " + userTurn);

        }

        ticTacToeBoard[userTurn] = 1;

        //don't allow the computer to cheat and overwrite the human's choices

        while (computerTurn == -1 || ticTacToeBoard[computerTurn] != 0)

        {
            computerTurn = random.Next(8);

            Console.WriteLine("Computer chooses " + computerTurn);

        }

        ticTacToeBoard[computerTurn] = 2;

        printTheBoard();
    }
}

Console.WriteLine("Player " + checkForAWinner() + " won the game!");
int checkForAWinner()
{
    //first row

    if (ticTacToeBoard[0] == ticTacToeBoard[1] && ticTacToeBoard[1] == ticTacToeBoard[2])
    {
        return ticTacToeBoard[0];
    }

    //second row
    if (ticTacToeBoard[3] == ticTacToeBoard[4] && ticTacToeBoard[4] == ticTacToeBoard[5])
    {
        return ticTacToeBoard[3];
    }

    //third row

    if (ticTacToeBoard[6] == ticTacToeBoard[7] && ticTacToeBoard[7] == ticTacToeBoard[8])
    {
        return ticTacToeBoard[6];
    }

    //first column

    if (ticTacToeBoard[0] == ticTacToeBoard[3] && ticTacToeBoard[3] == ticTacToeBoard[6])
    {
        return ticTacToeBoard[0];
    }

    //second column

    if (ticTacToeBoard[1] == ticTacToeBoard[4] && ticTacToeBoard[4] == ticTacToeBoard[7])
    {
        return ticTacToeBoard[1];
    }

    //third column

    if (ticTacToeBoard[2] == ticTacToeBoard[5] && ticTacToeBoard[5] == ticTacToeBoard[8])
    {
        return ticTacToeBoard[2];
    }

    //first diagonal

    if (ticTacToeBoard[0] == ticTacToeBoard[4] && ticTacToeBoard[4] == ticTacToeBoard[8])
    {
        return ticTacToeBoard[0];
    }

    //second diagonal

    if (ticTacToeBoard[2] == ticTacToeBoard[4] && ticTacToeBoard[4] == ticTacToeBoard[6])
    {
        return ticTacToeBoard[2];
    }

    return 0;
}
void printTheBoard()
{
    for (int i = 0; i < 9; i++)
    {
        //print the board
        //Console.WriteLine("Square " +  i + " contains " + ticTacToeBoard[i] );
        //print X or O for each square
        // 0 means unoccupied 1 means player 1 X and 2 means player 2 O
        if (ticTacToeBoard[i] == 0)
        {
            Console.Write(".");
        }

        if (ticTacToeBoard[i] == 1)
        {
            Console.Write("X");
        }

        if (ticTacToeBoard[i] == 2)
        {
            Console.Write("O");
        }

        //print a new line every third character.

        if (i == 2 || i == 5 || i == 8)
        {
            Console.WriteLine();
        }
    }
}