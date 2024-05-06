using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToeVersionTwo
{
    public partial class TicTacToeBoard : Form

    {
        public enum Player
        {
            X, O
        }

        Player currentPlayer;
        Random random = new Random();
        int playerWinCount = 0;
        int computerWinCount = 0;
        List<Button> buttons;

        public TicTacToeBoard()
        {
            InitializeComponent();
            RestartGame();
        }

        private void PlayerButtonClick(object sender, EventArgs e)
        {
            var button = (Button)sender;
            currentPlayer = Player.X;
            button.Text = currentPlayer.ToString();
            button.BackColor = Color.Violet;
            buttons.Remove(button);
            CheckWinner();
            CPUTurn.Start();
        }

        private void CheckWinner()
        {
            if(button1.Text == "X" && button2.Text == "X" && button3.Text == "X"||
               button4.Text == "X" && button5.Text == "X" && button6.Text == "X"||
               button7.Text == "X" && button8.Text == "X" && button9.Text == "X"||
               button1.Text == "X" && button4.Text == "X" && button7.Text == "X"||
               button2.Text == "X" && button5.Text == "X" && button8.Text == "X"||
               button3.Text == "X" && button6.Text == "X" && button9.Text == "X"||
               button1.Text == "X" && button5.Text == "X" && button9.Text == "X"||
               button3.Text == "X" && button5.Text == "X" && button7.Text == "X")
            {
                CPUTurn.Stop();
                MessageBox.Show("Player wins!");
                playerWinCount++;
                label1.Text = "Player Wins: " + playerWinCount;
                RestartGame();
            }
      else if (button1.Text == "O" && button2.Text == "O" && button3.Text == "O"||
               button4.Text == "O" && button5.Text == "O" && button6.Text == "O"||
               button7.Text == "O" && button8.Text == "O" && button9.Text == "O"||
               button1.Text == "O" && button4.Text == "O" && button7.Text == "O"||
               button2.Text == "O" && button5.Text == "O" && button8.Text == "O"||
               button3.Text == "O" && button6.Text == "O" && button9.Text == "O"||
               button1.Text == "O" && button5.Text == "O" && button9.Text == "O"||
               button3.Text == "O" && button5.Text == "O" && button7.Text == "O")
            {
                CPUTurn.Stop();
                MessageBox.Show("Computer wins!");
                computerWinCount++;
                label2.Text = "Computer Wins: " + computerWinCount;
                RestartGame();
            }
        }

        private void RestartGame(object sender, EventArgs e)
        {
            RestartGame();
        }

    
        private void RestartGame()
        {
            buttons = new List<Button> {button1, button2, button3, button4, 
                button5, button6, button7, button8, button9};

            foreach (Button button in buttons)
            {
                button.Enabled = true;
                button.Text = "?";
                button.BackColor = DefaultBackColor;
            }

        }

        private void ComputerMove(object sender, EventArgs e)
        {
            if(buttons.Count > 0)
            {
                int index = random.Next(buttons.Count);
                buttons[index].Enabled = false;
                currentPlayer = Player.O;
                buttons[index].Text = currentPlayer.ToString();
                buttons[index].BackColor = Color.CadetBlue;
                buttons.RemoveAt(index);
                CheckWinner();
                CPUTurn.Stop();
            }
        }
    }
}
