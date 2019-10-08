using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LightsOutGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static int size = 5;
        static int buttonSize = 60;
        Lamp[,] board = new Lamp[size, size];
        static int[,] neighbors = new int[,] { { 0, -1 }, { -1, 0 }, { 0, 1 }, { 1, 0 } };
        int row;
        int col;


        public MainWindow()
        {
            InitializeComponent();
            InitializeBoard();
        }

        private void InitializeBoard()
        {
            for (row = 0; row < board.GetLength(0); row++)
            {
                for (col = 0; col < board.GetLength(1); col++)
                {
                    Lamp l = new Lamp(row, col)
                    {
                        Height = buttonSize,
                        Width = buttonSize,
                        //b.Content = row*size+col,
                        Content = String.Empty,
                    };
                    l.Click += new RoutedEventHandler(btn_Click);
                    board[row, col] = l;
                    grid.Children.Add(l);
                }
            }

            int rowMiddle = (size - 1) / 2;
            int colMiddle = (size - 1) / 2;

            for (int i = 0; i < neighbors.GetLength(0); i++)
            {
                board[rowMiddle + neighbors[i, 0], colMiddle + neighbors[i, 1]].Flip();
            }
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            Lamp l = (Lamp)sender;
            Shoot(l.Row, l.Col);
        }

        private void Shoot(int row, int col)
        {
            int x = col;
            int y = row;

            board[y, x].Flip();

            for (int i = 0; i < neighbors.GetLength(0); i++)
            {
                int yCoord = y + neighbors[i, 0];
                int xCoord = x + neighbors[i, 1];

                if (yCoord >= 0 && xCoord >= 0 && yCoord < size && xCoord < size)
                {
                    board[yCoord, xCoord].Flip();
                }
            }

            if (IsOver()) { MessageBox.Show("You Win!"); }
        }
        private bool IsOver()
        {
            for (row = 0; row < board.GetLength(0); row++)
            {
                for (col = 0; col < board.GetLength(1); col++)
                {
                    if (board[row, col].IsOn) { return false; }
                }
            }
            return true;
        }
    }
}
