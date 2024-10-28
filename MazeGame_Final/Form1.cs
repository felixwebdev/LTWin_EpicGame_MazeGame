using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using System.Windows.Forms;

namespace MazeGame_Final
{
    public partial class Form1 : Form
    {
        Random rdn = new Random();
        string level;
        //SoundPlayer backSound = new SoundPlayer(P);
        SoundPlayer clickSound = new SoundPlayer(Properties.Resources.quiz2);
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            clickSound.Play();
            var ans = MessageBox.Show("Bạn chắc chứ dũng sĩ !!", "Thoát Game", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ans == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void EasyLevelClick(object sender, EventArgs e)
        {
            clickSound.Play();
            level = $"easy{rdn.Next(1, 9)}";
            Game GameConsole = new Game(level);
            GameConsole.Show();
        }

        private void MediumLevelClick(object sender, EventArgs e)
        {
            clickSound.Play();
            level = $"medium{rdn.Next(1, 9)}";
            Game GameConsole = new Game(level);
            GameConsole.Show();
        }

        private void HardLevelClick(object sender, EventArgs e)
        {
            clickSound.Play();
            level = $"hard{rdn.Next(1, 9)}";
            Game GameConsole = new Game(level);
            GameConsole.Show();
        }

        private void IntroClick(object sender, EventArgs e)
        {
            clickSound.Play();
            intro introform = new intro();
            introform.Show();
        }

        private void WinnerHis_Btn_Click(object sender, EventArgs e)
        {
            clickSound.Play();
            historyWinner winner = new historyWinner();
            winner.Show();
        }
    }
}
