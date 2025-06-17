using System;
using System.Drawing;
using System.Windows.Forms;

namespace GreenPuzzle
{
    public partial class PuzzleForm : Form
    {
        private GameButton[,] gameBoard = new GameButton[8, 8];

        public PuzzleForm()
        {
            InitializeComponent();
            CreateGameBoard();
        }

        private void CreateGameBoard()
        {
            int buttonSize = 25;
            int spacing = 5;
            int startY = menuStrip1.Height + 10;

            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    GameButton btn = new GameButton();
                    btn.Column = col;
                    btn.Row = row;
                    btn.Size = new Size(buttonSize, buttonSize);
                    btn.Location = new Point(
                        col * (buttonSize + spacing), 
                        startY + row * (buttonSize + spacing));
                    btn.BackColor = Color.White;
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.Click += GameButton_Click;
                    
                    gameBoard[col, row] = btn;
                    this.Controls.Add(btn);
                }
            }
        }

        private void GameButton_Click(object sender, EventArgs e)
        {
            GameButton clickedButton = (GameButton)sender;
            int col = clickedButton.Column;
            int row = clickedButton.Row;

            for (int i = 0; i < 8; i++)
            {
                SwitchColor(gameBoard[i, row]);
            }
            
            for (int i = 0; i < 8; i++)
            {
                SwitchColor(gameBoard[col, i]);
            }
                        SwitchColor(clickedButton);

            if (CheckSolution())
            {
                MessageBox.Show("Поздравляем! Головоломка решена!", 
                               "Успех", 
                               MessageBoxButtons.OK, 
                               MessageBoxIcon.Information);
            }
        }

        private void SwitchColor(GameButton btn)
        {
            btn.BackColor = (btn.BackColor == Color.White) 
                ? Color.ForestGreen 
                : Color.White;
        }

        private bool CheckSolution()
        {
            foreach (var button in gameBoard)
            {
                if (button.BackColor != Color.ForestGreen)
                    return false;
            }
            return true;
        }

        private void ResetGame(object sender, EventArgs e)
        {
            foreach (var button in gameBoard)
            {
                button.BackColor = Color.White;
            }
        }

        private void ExitApp(object sender, EventArgs e)
        {
            this.Close();
        }
    }

    public class GameButton : Button
    {
        public int Column { get; set; }
        public int Row { get; set; }
    }
}