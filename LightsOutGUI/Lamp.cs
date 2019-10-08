using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace LightsOutGUI
{
    class Lamp : Button
    {
        bool isOn;
        Brush on = Brushes.Yellow;
        Brush off = Brushes.Black;

        int row;
        int col;

        public Lamp(int row, int col) {
            isOn = true;
            Background = on;
            this.row = row;
            this.col = col;
        }

        public int Row { get => row; }
        public int Col { get => col; }
        public bool IsOn { get => isOn; set => isOn = value; }

        public void Flip() {
            if (isOn)
            {
                isOn = false;
                Background = off;
            }
            else {
                isOn = true;
                Background = on;
            }
        }
    }
}
