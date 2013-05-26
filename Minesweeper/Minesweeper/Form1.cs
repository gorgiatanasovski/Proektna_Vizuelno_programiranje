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
using System.Diagnostics;
namespace Minesweeper
{
    public partial class Form1 : Form
    {
        
        public enum Level
        {
            Beginner,
            Normal,
            Hard,
            Custom
        }
        public Level l;
        public static obj [][] minefield;
        public static int maxX { get; set; }
        public static int maxY { get; set; }
        public static int MinesM { get; set; }
        public static int Opened { get; set; }
        public static Label Score { get; set; }
        public static Label MinesL { get; set; }
        public static int MinesTmp { get; set; }
        public Form1()
        {
            
            InitializeComponent();
            Bitmap Cbitmap = new Bitmap(Resources.mine2, 64,64);
            Opened = 0;

            Score = new Label();
            Score.Show();
            MinesL = new Label();
            MinesL.Show();
            Controls.Add(MinesL);
            Controls.Add(Score);
            Cbitmap.MakeTransparent(Color.White);
            System.IntPtr icH = Cbitmap.GetHicon();
            Icon = Icon.FromHandle(icH);
            //Icon = new IconConverter(Resources.mine2);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            
            button1.Image = new Bitmap(Resources.sun, button1.Height - 2, button1.Width - 2);
            minefield = new obj[20][];
            for (int i = 0; i < 20; i++)
            {
                minefield[i] = new obj[20];
            }
            initializeField();
            l = Level.Beginner;
            
            newGame();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        //gi kreira site polinja 20x20
        public void initializeField()
        {
            int x = 10, y = 75;
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    minefield[i][j] = new obj(52, y, x, "none",i,j);
                    Controls.Add(minefield[i][j].b);
                    x += 51;
                }
                x = 10;
                y += 51;
            }
        }


        // zapocnuva nova igra
        public void newGame()
        {
            
            cleanfield();
            if (l == Level.Beginner)
            {
                canvas(l, 8, 5,14);
                maxX = 8;
                maxY = 5;
                MinesM = 14;
            }
            else if (l == Level.Normal)
            {
                canvas(l, 10, 7,24);
                maxX = 10;
                maxY = 7;
                MinesM = 24;
            }
            else if (l == Level.Hard)
            {
                canvas(l, 15, 9, 45);
                maxX = 15;
                maxY = 9;
                MinesM = 45;
            }
            else if (l == Level.Custom)
            {
                canvas(l, maxX, maxY, MinesM);
            }
        }


        //go rasporeduva ekranot 
        public void canvas(Level lvl,int sizeX,int sizeY,int mines)
        {
            
            List<int> l1 = new List<int>();
            List<int> l2 = new List<int>();
            for (int i = 0; i < sizeX; i++)
            {
                for (int j = 0; j < sizeY; j++)
                {
                    l1.Add(10 * i + j);
                }
            }
            
            l1 = ShuffleList<int>(l1);

            for (int i = 0; i < mines; i++)
            {
                l2.Add(l1[i]);
            }
            MinesTmp = mines;
            this.Width = sizeX * 52 + 30;
            this.Height = sizeY * 52 + 120;
            button1.Location = new Point(this.Width/2-25,27);
            Score.Text = "Score " + 0;
            Score.Location = new Point(this.Width - 100, 38);
            MinesL.Location = new Point(30, 38);
            MinesL.Text = "Mines left " + mines;
            for (int i = 0; i < sizeY; i++)
            {
                for (int j = 0; j < sizeX; j++)
                {
                    if (l2.Contains(10 * j + i))
                    {
                        minefield[i][j].objSet("mine");
                    }
                    else
                    {
                        minefield[i][j].objSet("none");
                    }
                }
                
            }
            for (int i = 19; i >=0; i--)
            {
                for (int j = 19; j >=0; j--)
                {
                    if (i > sizeY - 1 || j > sizeX - 1)
                    {
                        minefield[i][j].b.Hide();
                    }
                    
                }

            } 
            int p;
            for (int i = 0; i < sizeY; i++)
            {
                for (int j = 0; j < sizeX; j++)
                {
                    p = surround(i,j,sizeY,sizeX);
                    if (p > 0 && minefield[i][j].b.Name!="mine")
                    {
                        minefield[i][j].val = p;
                        minefield[i][j].b.Name = "number";
                    }
                    else
                    {
                        minefield[i][j].val = p;
                    }
                }

            }

        }

        //gi vrakja site buttons vo pocetna sostojba
        public void cleanfield()
        {
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    if (minefield[i][j].used)
                    {
                        minefield[i][j].objReset();
                    }

                }
            }
            Opened = 0;
            Score.Text = "" + 0;
        }

        private List<E> ShuffleList<E>(List<E> inputList)
        {
            List<E> randomList = new List<E>();

            Random r = new Random();
            int randomIndex = 0;
            while (inputList.Count > 0)
            {
                randomIndex = r.Next(0, inputList.Count); //Choose a random object in the list
                randomList.Add(inputList[randomIndex]); //add it to the new, random list
                inputList.RemoveAt(randomIndex); //remove to avoid duplicates
            }

            return randomList; //return the new random list
        }

        //brz pristap za nova igra
        private void button1_Click(object sender, EventArgs e)
        {
            newGame();
        }

        //gleda kolku mini ima okolu poleto na koe e kliknato
        public int surround(int i, int j,int x,int y)
        {
            int m = 0;
            if (i>0 && minefield[i-1][j].b.Name == "mine")
            {
                m++;
            }
            if ((i > 0  && j < y-1) && minefield[i - 1][j + 1].b.Name == "mine" )
            {
                m++;
            }
            if ( j < y-1 && minefield[i][j + 1].b.Name == "mine"  )
            {
                m++;
            }
            if ((i < x-1 && j < y - 1) && minefield[i + 1][j + 1].b.Name == "mine")
            {
                m++;
            }
            if ( i < x-1 && minefield[i + 1][j].b.Name == "mine" )
            {
                m++;
            }
            if ((i < x-1 && j > 0) && minefield[i + 1][j - 1].b.Name == "mine")
            {
                m++;
            }
            if ( j > 0 && minefield[i][j - 1].b.Name == "mine" )
            {
                m++;
            }
            if ((i > 0  && j > 0 ) && minefield[i - 1][j - 1].b.Name == "mine" )
            {
                m++;
            }
            return m;
        }

        //normal_click
        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            l = Level.Normal;
            newGame();
        }

        //beginner_click
        private void beginner_Click(object sender, EventArgs e)
        {
            l = Level.Beginner;
            newGame();
        }

        //hard_click
        private void hard_Click(object sender, EventArgs e)
        {
            l = Level.Hard;
            newGame();
        }

        private void Custom_Click(object sender, EventArgs e)
        {
            CustomGame Custom =  new CustomGame();
            
            if (Custom.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                maxX = Custom.X;
                maxY = Custom.Y;
                MinesM = Custom.M;
                l = Level.Custom;
                newGame();
            }
            //Custom.Close();

        }

        public static void openCleanArea(int i1, int j1 )
        {
           
            int y = maxX;
            int x = maxY; 
            int i = i1;
            int j = j1;
            if (i > 0 && !minefield[i - 1][j].opened)
            {
                //MessageBox.Show("gore");
                //gore
                minefield[i - 1][j].renable = false;
                minefield[i - 1][j].opened = true;
                if (minefield[i - 1][j].b.Name == "number")
                {
                    minefield[i - 1][j].setImage();
                    
                }
                else if (minefield[i - 1][j].b.Name == "none")
                {
                    minefield[i - 1][j].b.Enabled = false;
                    openCleanArea(i-1,j);
                }
            }
            //gore desno
            if (i > 0 && j < y - 1 && !minefield[i - 1][j + 1].opened)
            {
                //MessageBox.Show("gore desno");
                minefield[i - 1][j + 1].renable = false;
                minefield[i - 1][j + 1].opened = true;
                
                if (minefield[i - 1][j + 1].b.Name == "number")
                {
                    minefield[i - 1][j + 1].setImage();
                    
                }
                else if (minefield[i - 1][j+1].b.Name == "none")
                {
                    minefield[i - 1][j + 1].b.Enabled = false;
                    openCleanArea(i-1,j+1);
                }
            }
            //desno
            if (j < y-1 && !minefield[i][j + 1].opened)
            {
                //MessageBox.Show("desno");
                minefield[i][j + 1].renable = false;
                minefield[i][j + 1].opened = true;

                if (minefield[i][j + 1].b.Name == "number")
                {
                    minefield[i][j + 1].setImage();
                    
                }
                else if (minefield[i][j + 1].b.Name == "none")
                {
                    minefield[i][j + 1].b.Enabled = false;
                    openCleanArea(i,j+1);
                }
            }
            //dole desno
            if ((i < x - 1 && j < y - 1) && !minefield[i + 1][j + 1].opened)
            {
                //MessageBox.Show("dole desno");
                minefield[i + 1][j + 1].renable = false;
                minefield[i+1][j + 1].opened = true;

                if (minefield[i + 1][j + 1].b.Name == "number")
                {
                    minefield[i + 1][j + 1].setImage();
                    
                }
                else if (minefield[i + 1][j + 1].b.Name == "none")
                {
                    minefield[i + 1][j + 1].b.Enabled = false;
                    openCleanArea(i+1,j+1);
                }
            }
            //dole
            if (i < x - 1 && !minefield[i + 1][j].opened)
            {
                //MessageBox.Show("dole");
                minefield[i + 1][j ].renable = false;
                minefield[i + 1][j ].opened = true;

                if (minefield[i + 1][j].b.Name == "number")
                {
                    minefield[i + 1][j].setImage();
                    
                }
                else if (minefield[i + 1][j].b.Name == "none")
                {
                    minefield[i + 1][j].b.Enabled = false;
                    openCleanArea(i+1,j);
                }
            }
            //dole levo
            if ((i < x - 1 && j > 0) && !minefield[i + 1][j - 1].opened)
            {
                //MessageBox.Show("dole levo");
                minefield[i + 1][j - 1].renable = false;
                minefield[i + 1][j - 1].opened = true;

                if (minefield[i + 1][j - 1].b.Name == "number")
                {
                    minefield[i + 1][j - 1].setImage();
                    
                }
                else if (minefield[i + 1][j - 1].b.Name == "none")
                {
                    minefield[i + 1][j - 1].b.Enabled = false;
                    openCleanArea(i+1,j-1);
                }
            }
            //levo
            if (j > 0 && !minefield[i][j - 1].opened)
            {
                //MessageBox.Show("levo");
                minefield[i][j - 1].renable = false;
                minefield[i][j - 1].opened = true;

                if (minefield[i][j - 1].b.Name == "number")
                {
                    minefield[i][j - 1].setImage();
                    
                }
                else if (minefield[i][j - 1].b.Name == "none")
                {
                    minefield[i][j - 1].b.Enabled = false;
                    openCleanArea(i,j-1);
                }
            }
            //gore levo
            if ((i > 0 && j > 0) && !minefield[i - 1][j - 1].opened)
            {
                //MessageBox.Show("gore levo");
                minefield[i-1][j - 1].renable = false;
                minefield[i - 1][j - 1].opened = true;

                if (minefield[i - 1][j - 1].b.Name == "number")
                {
                    minefield[i - 1][j - 1].setImage();
                    
                }
                else if (minefield[i - 1][j - 1].b.Name == "none")
                {
                    minefield[i - 1][j - 1].b.Enabled = false;
                    openCleanArea(i-1,j-1);
                }
            }
            countToWin();
        }

        public static void countToWin()
        {
            //MessageBox.Show("active");
            
            Opened = 0;
            for (int i = 0; i < maxY; i++)
            {
                for (int j = 0; j < maxX; j++)
                {
                    if (minefield[i][j].opened == true&&minefield[i][j].b.Name!="mine")
                    {
                        Opened++;
                    }
                }
            }
            Score.Text = "Score "+ Opened;
            //f.Score.Text = Opened.ToString();
            if (Opened == maxX * maxY - MinesM)
            {
                MessageBox.Show("YOU WON!!!");
                //MessageBox.Show("Score: " + Opened);
                for (int i = 0; i < maxY; i++)
                {
                    for (int j = 0; j < maxX; j++)
                    {

                        minefield[i][j].renable = false;
                        minefield[i][j].opened = true;

                    }
                }
                MinesL.Text = "Mines left "+0;
            }

        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            newGame();
        }

        private void ExitGame_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to exit? ","", MessageBoxButtons.YesNo ) == DialogResult.Yes)
            {
                Close();
            }
        }

        private void Help_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Оваа игра е изработена од страна на:\nЃорѓи Атанасовски 115007\nКристијан Атанасовски 115008");
        }
        
    }








    public class obj
    {
        public  enum Status
        {
            mine,
            flag,
            question,
            none,
            number
        }
        public Button b { get; set; }
        public bool used { get; set; }       
        Status stat { get; set; }
        public int clickt { get; set; }
        public bool renable { get; set; }
        public int val { get; set; }
        public bool opened { get; set; }
        public int pozi { get; set; }
        public int pozj { get; set; }

        public void objSet(string s)
        {
            opened = false;
            used = true;
            b.Name = s;
            b.Show();
            renable = true;
        }

        public void objReset()
        {
            opened = false;
            b.Name = "none";
            b.Text = "";
            stat = Status.none;
            used = false;
            renable = true;
            b.Image = new Button().Image;
            b.Enabled = true;
            clickt = 0;
        }

        public obj(int size, int y, int x, string n,int pozi,int pozj)
        {
            opened = false;
            used = false;
            renable = true;
            clickt = 0;
            b = new Button();
            stat = Status.mine;
            b.Name = n;
            b.Location = new System.Drawing.Point(x, y);
            b.Size = new System.Drawing.Size(size,size);
            b.MouseDown += new MouseEventHandler(this.ButtonClick);
            b.Hide();
            this.pozi = pozi;
            this.pozj = pozj;
        }


        private void ButtonClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && renable)
            {
                if (clickt == 0)
                {
                    b.Image = new Bitmap(Resources.flag, b.Height - 2, b.Width - 2);
                    stat = Status.flag;
                    clickt = 1;
                }
                else if (clickt == 1)
                {
                    b.Image = new Bitmap(Resources.question, b.Height - 2, b.Width - 2);
                    stat = Status.question;
                    clickt = 2;
                }
                else if (clickt == 2)
                {
                    b.Image = new Button().Image;
                    stat = Status.none;
                    clickt = 0;
                }
            }
            if (e.Button == MouseButtons.Left&&!opened&&clickt==0)
            {
                if (b.Name == "mine")
                {
                    b.Image = new Bitmap(Resources.mine, b.Height - 2, b.Width - 2);
                    stat = Status.mine;
                    renable = false;
                    opened = true;
                    OpenAllMines();
                }
                else if (b.Name == "number")
                {
                    stat = Status.number;
                    setImage();
                    renable = false;
                    opened = true;
                    Form1.countToWin();
                }
                else if (b.Name == "none")
                {
                    Form1.openCleanArea(pozi,pozj);
                    b.Enabled = false;
                    renable = false;
                    opened = true;
                }
            }
        }

        public void OpenAllMines()
        {
            for (int i = 0; i < Form1.maxY; i++)
            {
                for (int j = 0; j < Form1.maxX; j++)
                {
                    if (Form1.minefield[i][j].b.Name == "mine")
                    {
                        if (Form1.minefield[i][j].clickt == 1)
                        {
                            Form1.minefield[i][j].b.Image = new Bitmap(Resources.hamlet_sm, Form1.minefield[i][j].b.Height - 4, Form1.minefield[i][j].b.Width - 4);
                            Form1.MinesTmp-=1;
                            Form1.MinesL.Text = "Mines Left "+Form1.MinesTmp;
                        }
                        else
                        {
                            Form1.minefield[i][j].b.Image = new Bitmap(Resources.mine, Form1.minefield[i][j].b.Height - 2, Form1.minefield[i][j].b.Width - 2);
                        }
                        Form1.minefield[i][j].renable = false;
                        Form1.minefield[i][j].opened = true;
                    }
                    else
                    {
                        if (Form1.minefield[i][j].b.Name == "number" && Form1.minefield[i][j].clickt == 1)
                        {
                            Form1.minefield[i][j].b.Image = new Bitmap(Resources.nobomb, Form1.minefield[i][j].b.Height - 2, Form1.minefield[i][j].b.Width - 2);
                        }
                        Form1.minefield[i][j].renable = false;
                        Form1.minefield[i][j].opened = true;
                    }
                }
            }
            MessageBox.Show("You lost");
            //MessageBox.Show("Your Score Is " + Form1.Opened);
        }

        //postavuva slika na polinjata so brojka
        public void setImage()
        {
            if (val == 1)
            {
                b.Image = new Bitmap(Resources.one, b.Height - 3, b.Width - 3);
            }
            if (val == 2)
            {
                b.Image = new Bitmap(Resources.two, b.Height - 3, b.Width - 3);
            }
            if (val == 3)
            {
                b.Image = new Bitmap(Resources.three, b.Height - 3, b.Width - 3);
            }
            if (val == 4)
            {
                b.Image = new Bitmap(Resources.four, b.Height - 3, b.Width - 3);
            }
            if (val == 5)
            {
                b.Image = new Bitmap(Resources.five, b.Height - 3, b.Width - 3);
            }
            if (val == 6)
            {
                b.Image = new Bitmap(Resources.six, b.Height - 3, b.Width - 3);
            }
            if (val == 7)
            {
                b.Image = new Bitmap(Resources.seven, b.Height - 3, b.Width - 3);
            }
            if (val == 8)
            {
                b.Image = new Bitmap(Resources.eight, b.Height - 3, b.Width - 3);
            }
        }
        
        

    }
}





//Timer MyTimer;
//public Form1()
//{
//    InitializeComponent();
//    //WindowState = FormWindowState.Minimized;


//    f = new Form();
//    f.Height = 300;
//    f.Width = 500;
//    f.StartPosition = FormStartPosition.CenterScreen;
//    f.FormBorderStyle = FormBorderStyle.None;
//    f.BackgroundImage = new Bitmap(Resources.hamlet_sm,500,300);
//    f.Text = "prva";
//    this.Hide();
//    f.Show();
//    //f.ShowDialog();
//    MyTimer = new Timer();
//    MyTimer.Interval = (5000); // 45 mins
//    MyTimer.Tick += new EventHandler(MyTimer_Tick);
//    MyTimer.Start();
//}

//private void MyTimer_Tick(object sender, EventArgs e)
//{
//    //MessageBox.Show("The form will now be closed.", "Time Elapsed");
//    f.Close();
//    MyTimer.Stop();
//    this.Hide();
//    //WindowState = FormWindowState.Normal;

//}