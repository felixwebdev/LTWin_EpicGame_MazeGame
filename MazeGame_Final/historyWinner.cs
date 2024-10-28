using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MazeGame_Final
{
    public partial class historyWinner : Form
    {
        public historyWinner()
        {
            InitializeComponent();
            FileStream f = new FileStream("data.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(f);

            string data = sr.ReadToEnd();
            f.Close();

            txtWinner.Text = data;
        }
    }
}
