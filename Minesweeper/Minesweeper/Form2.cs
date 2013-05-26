using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Minesweeper.Properties;

namespace Minesweeper
{
    public partial class CustomGame : Form
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int M { get; set; }
        public CustomGame()
        {
            InitializeComponent();
            Bitmap Cbitmap = new Bitmap(Resources.mine2, 64, 64);
            Cbitmap.MakeTransparent(Color.White);
            System.IntPtr icH = Cbitmap.GetHicon();
            Icon = Icon.FromHandle(icH);
        }

        private void Start_custom_Click(object sender, EventArgs e)
        {
            X = (int)CustomX.Value;
            Y = (int)CustomY.Value;
            M = (int)CustomMines.Value;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

        private void CustomMines_Validating(object sender, CancelEventArgs e)
        {
            X = (int)CustomX.Value;
            Y = (int)CustomY.Value;
            M = (int)CustomMines.Value;
            if (M>X*Y-1)
            {
                e.Cancel = true;
                MinesError.SetError(CustomMines, "Too much mines");
            }
            else
            {
                MinesError.SetError(CustomMines, null);
            }
        }

    }
}
