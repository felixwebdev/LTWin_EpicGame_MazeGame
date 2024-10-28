using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Media;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MazeGame_Final
{
    public partial class Game : Form
    {
        #region KhaiBao
        bool goLeft, goRight, goUp, goDown, gameOver;
        int rows, cols;
        int CellSize;
        int[,] maze;
        int score;
        string gameLevel;
        int timeSurvival;
        string statusPlayer = "kright";
        Point playerPosition;
        List<Point> goalPositions = new List<Point>();
        Point oldPlayerPosition;
        PictureBox[,] pictureBoxes;
        Stack<Tuple<string, string>> stQuiz = new Stack<Tuple<string, string>>();
        SoundPlayer moveSound = new SoundPlayer(Properties.Resources.move2);
        SoundPlayer claimCoinSound = new SoundPlayer(Properties.Resources.coin_claim);
        SoundPlayer answerSound = new SoundPlayer(Properties.Resources.quiz2);
        #endregion
        public Game(string level)
        {
            gameLevel = level;
            InitializeComponent();
            InitMaze(level);
            InitPictureBoxes();
            StartCountdown();
        }
        private void InitMaze(string _level)
        {
            string _levelS = _level.Substring(0, _level.Length - 1);
            if (_levelS == "easy")
            {
                timeSurvival = 60;
                CellSize = 50;
            }
            else if (_levelS == "medium")
            {
                timeSurvival = 90;
                CellSize = 40;
            }
            else
            {
                timeSurvival = 120;
                CellSize = 30;
            }

            string resourceName = _level; 
            var resourceManager = Properties.Resources.ResourceManager;
            string fileContent = resourceManager.GetString(resourceName);

            string[] linesArray = fileContent.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

            rows = cols = int.Parse(linesArray[0]);
            maze = new int[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                string[] line = linesArray[i + 1].Trim().Split(' ');
                for (int j = 0; j < cols; j++)
                {
                    maze[i, j] = int.Parse(line[j]);
                }
            }

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (maze[i, j] == 3)
                    {
                        Point goalPosition = new Point(i, j);
                        goalPositions.Add(goalPosition);
                    }
                }
            }

            for (int i = rows + 1; i < linesArray.Length; i += 2)
            {
                if (i + 1 < linesArray.Length)
                {
                    string question = linesArray[i].Trim();
                    string answer = linesArray[i + 1].Trim();
                    stQuiz.Push(new Tuple<string, string>(question, answer));
                }
            }

            oldPlayerPosition = playerPosition = new Point(rows / 2, cols / 2);
        }
        private void InitPictureBoxes()
        {
            pictureBoxes = new PictureBox[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    PictureBox pb = new PictureBox
                    {
                        Width = CellSize,
                        Height = CellSize,
                        Location = new Point(j * CellSize, i * CellSize + 112),
                        BorderStyle = BorderStyle.FixedSingle,
                        BackgroundImage = Properties.Resources.floor,
                        BackgroundImageLayout = ImageLayout.Stretch
                };

                    if (maze[i, j] == 0)
                    {
                        pb.Image = Properties.Resources.wall;
                        pb.SizeMode = PictureBoxSizeMode.StretchImage;
                        pb.Tag = "0";
                    }
                    else if (maze[i, j] == 1)
                    {
                        pb.Image = Properties.Resources.floor;
                        pb.SizeMode = PictureBoxSizeMode.StretchImage;
                        pb.Tag = "1";
                    }
                    else if (maze[i, j] == 2)
                    {
                        pb.Image = Properties.Resources.quiz;
                        pb.SizeMode = PictureBoxSizeMode.StretchImage;
                        pb.Tag = "2";
                    }
                    else if (maze[i, j] == 3)
                    {
                        pb.Image = Properties.Resources.DoorWin;
                        pb.SizeMode = PictureBoxSizeMode.Zoom;
                        pb.Tag = "3";
                    }
                    else if (maze[i, j] == 4)
                    {
                        pb.Image = Properties.Resources.coin;
                        pb.SizeMode = PictureBoxSizeMode.StretchImage;
                        pb.Tag = "4";
                    }
                    pb.BringToFront();
                    this.Controls.Add(pb);
                    pictureBoxes[i, j] = pb;
                }
            }

            UpdatePlayerPosition(statusPlayer);
            this.ClientSize = new Size(rows * CellSize, cols * CellSize + 110);
        }
        private void UpdatePlayerPosition(string statusPlayer)
        {
            pictureBoxes[oldPlayerPosition.X, oldPlayerPosition.Y].Image = Properties.Resources.floor;
            PictureBox player = pictureBoxes[playerPosition.X, playerPosition.Y] as PictureBox;

            if (statusPlayer == "kup")
                player.Image = Properties.Resources.kup;
            else if (statusPlayer == "kdown")
                player.Image = Properties.Resources.kdown;
            else if (statusPlayer == "kleft")
                player.Image = Properties.Resources.kleft;
            else if (statusPlayer == "kright")
                player.Image = Properties.Resources.kright;
        }
        private void Game_Load(object sender, EventArgs e)
        {
        }
        private void StartCountdown()
        {
            health_Bar.Maximum = timeSurvival;
            health_Bar.Value = health_Bar.Maximum; 
            CountDownTimer.Start(); 
        }
        private void CountDownTimerEvent(object sender, EventArgs e)
        {
            if (health_Bar.Value > 0)
            {
                health_Bar.Value -= 1; 
            }
            else
            {
                CountDownTimer.Stop();
                pictureBoxes[playerPosition.X, playerPosition.Y].Image = Properties.Resources.kdead;
                MessageBox.Show("Đã hết thời gian!");
                Exit();
            }
        }
        private void GameTimeEvent(object sender, EventArgs e)
        {
            txtScore.Text = score.ToString();
        }
        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if (gameOver == true) return;
            if (e.KeyCode == Keys.Escape) { 
                var ans = MessageBox.Show("Bạn có chắc muốn thoát ?", "Thoát game đang chơi",
                                           MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (ans == DialogResult.Yes) Exit();
            }
            oldPlayerPosition = playerPosition;
            Point newPosition = playerPosition;
            PictureBox player = pictureBoxes[playerPosition.X, playerPosition.Y] as PictureBox;

            if (e.KeyCode == Keys.Up && goUp == false)
            {
                goUp = true;
                newPosition.X--;
                player.Image = Properties.Resources.kup;
                statusPlayer = "kup";
            }
            if (e.KeyCode == Keys.Down && goDown == false)
            {
                goDown = true;
                newPosition.X++;
                player.Image = Properties.Resources.kdown;
                statusPlayer = "kdown";
            }
            if (e.KeyCode == Keys.Left && goLeft == false)
            {
                goLeft = true;
                newPosition.Y--;
                player.Image = Properties.Resources.kleft;
                statusPlayer = "kleft";
            }
            if (e.KeyCode == Keys.Right && goRight == false)
            {
                goRight = true;
                newPosition.Y++;
                player.Image = Properties.Resources.kright;
                statusPlayer = "kright";
            }

            if (IsValidMove(newPosition))
            {
                moveSound.Play();
                playerPosition = newPosition;
                UpdatePlayerPosition(statusPlayer);
                if (maze[newPosition.X, newPosition.Y] == 4)
                {
                    score++;
                    maze[newPosition.X, newPosition.Y] = 1;
                    pictureBoxes[newPosition.X, newPosition.Y].Tag = "1";
                    claimCoinSound.Play();
                }
                else if (maze[newPosition.X, newPosition.Y] == 2)
                {
                    answerSound.Play();
                    bool ans = AskQuestion();
                    if (ans)
                    {
                        maze[newPosition.X, newPosition.Y] = 1;
                        pictureBoxes[newPosition.X, newPosition.Y].Tag = "1";

                    }
                    else
                    {
                        maze[newPosition.X, newPosition.Y] = 0;
                        pictureBoxes[newPosition.X, newPosition.Y].Tag = "0";
                        pictureBoxes[newPosition.X, newPosition.Y].Image = Properties.Resources.wall;
                        playerPosition = oldPlayerPosition;
                        UpdatePlayerPosition(statusPlayer);
                        if (!PathToGoal())
                        {
                            CountDownTimer.Stop();  
                            pictureBoxes[playerPosition.X, playerPosition.Y].Image = Properties.Resources.kdead;
                            MessageBox.Show("Toàn bộ lối ra đã bị chặn!!", "Cảnh báo");
                            Exit();   
                        }
                    }
                }
            }
            foreach(var goalPosition in goalPositions)
            {
                if (playerPosition == goalPosition)
                {
                    CountDownTimer.Stop();
                    MessageBox.Show("Chúc mừng dũng sĩ!\n Nỗ lực của bạn đã được đền đáp. \n Số điểm đạt được: " + score.ToString());
                    HistoryWinner();    
                    Exit();
                }
            }
        }
        private void HistoryWinner()
        {
            List<string> data = new List<string>()
            {
                 DateTime.Now.ToString(),
                "Cấp: " + gameLevel.Substring(0,gameLevel.Length-1),
                "Điểm: " + score.ToString(),
                "Thời gian vượt ải: " + (timeSurvival - health_Bar.Value).ToString() + " giây",
                "=============================================="
            };
            FileStream f = new FileStream("data.txt", FileMode.Append, FileAccess.Write);  
            StreamWriter sr = new StreamWriter(f);

            foreach (var line in data)
            {
                sr.WriteLine(line);
            }
      
            sr.Flush(); 
            f.Close();
        }
        private bool AskQuestion()
        {
            Tuple<string, string> tp = stQuiz.Peek();
            stQuiz.Pop();
            DialogResult result = MessageBox.Show(tp.Item1,
                                                  "Thử thách của thần Athena",
                                                  MessageBoxButtons.YesNo,
                                                  MessageBoxIcon.Question,
                                                  MessageBoxDefaultButton.Button1);
            string answer = "true";
            if (result == DialogResult.Yes)
            {
                answer = "true";
                
            }
            else if (result == DialogResult.No)
            {
                answer = "false";
            }

            if (answer == tp.Item2)
            {
                MessageBox.Show("Bạn đã vượt qua thử thách! Mời đi tiếp !");
                claimCoinSound.Play();
                return true;
            }
            else
            {
                MessageBox.Show("Tiếc quá lùi lại đi!");
                answerSound.Play();
                return false;
            }
        }
        private bool PathToGoal()
        {
            foreach (Point goal in goalPositions)
            {
                if (BFS(playerPosition, goal)) return true;
            }
            return false;
        }
        private bool BFS(Point s, Point f)
        {
            if (s.X < 0 || s.X >= rows || s.Y < 0 || s.Y >= cols ||
                f.X < 0 || f.X >= rows || f.Y < 0 || f.Y >= cols ||
                maze[s.X, s.Y] == 0 || maze[f.X, f.Y] == 0)
            {
                return false;
            }

            Queue<(int, int)> queue = new Queue<(int, int)>();
            queue.Enqueue((s.X, s.Y));

            bool[,] visited = new bool[rows, cols];
            visited[s.X, s.Y] = true;

            int[,] dirs = { { -1, 0 }, { 1, 0 }, { 0, -1 }, { 0, 1 } };

            while (queue.Count > 0)
            {
                var curr = queue.Dequeue();

                if (curr.Item1 == f.X && curr.Item2 == f.Y)
                {
                    return true;
                }

                for (int i = 0; i < 4; i++)
                {
                    int newX = curr.Item1 + dirs[i, 0];
                    int newY = curr.Item2 + dirs[i, 1];
                  
                    if (newX >= 0 && newX < rows &&
                        newY >= 0 && newY < cols &&
                        maze[newX, newY] != 0 && !visited[newX, newY])
                    {
                        queue.Enqueue((newX, newY));
                        visited[newX, newY] = true; 
                    }
                }
            }

            return false; 
        }
        private bool IsValidMove(Point position)
        {
            if (position.X < 0 || position.X >= maze.GetLength(1) ||
                position.Y < 0 || position.Y >= maze.GetLength(0))
            {
                return false;
            }
            return maze[position.X, position.Y] != 0;
        }
        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                goUp = false;
            }
            if (e.KeyCode == Keys.Down)
            {
                goDown = false;
            }
            if (e.KeyCode == Keys.Left)
            {
                goLeft = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                goRight = false;
            }
        }
        private void Exit()
        {
            this.Close();
        }
    }
}
