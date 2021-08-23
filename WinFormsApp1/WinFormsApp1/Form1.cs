using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public bool pic;
        public int next_Leval = 1;
        public int movecount;
        public PictureBox[] Cases;
        public List<PictureBox> goals;
        
        
        public Form1()
        {
            InitializeComponent();
            //array
            Cases = new PictureBox[] {c0,c1,c2,c3,c4,c5,c6,c7,
                                      c8,c9,c10,c11,c12,c13,c14,c15,
                                      c16,c17,c18,c19,c20,c21,c22,c23,
                                      c24,c25,c26,c27,c28,c29,c30,c31,
                                      c32,c33,c34,c35,c36,c37,c38,c39,
                                      c40,c41,c42,c43,c44,c45,c46,c47,
                                      c48,c49,c50,c51,c52,c53,c54,c55,
                                      c56,c57,c58,c59,c60,c61,c62,c63};
            //goals = new List<PictureBox>();

        } 

        private void Form1_Load(object sender, EventArgs e)
        {
            // passing levals
            
            if (next_Leval == 1)
            {
               Leval1();
            }

            if (next_Leval == 2)
            {
                Leval2();
            }
            else if (next_Leval == 3)
            {
                Leval3();
            }
            else if (next_Leval == 4)
            {
                Leval4();
            }
            else if (next_Leval == 5)
            {
                Leval5();
            }
            

        }

        //position of the player
        int Position()
        {
            for (int i = 0; i < 64; i++)
                if (Cases[i].Image == player.Image)
                    return i;

            return 0;
        }

        //Right
        void Move_Right(int i)
        {
            //if cases[i+l].image is a 'wall' player can't move


            // if cases[i+l].image is a 'goal' or null platayer can mvoe

            if (Cases[i + 1].Image == goal.Image || Cases[i + 1].Image == null)
            {
                //player position
                Cases[i + 1].Image = player.Image;

                if (goals.Contains(Cases[i]))
                {
                    Cases[i].Image = goal.Image;
                }
                else
                {
                    Cases[i].Image = null;
                }

            }

            //case if it 'box' or 'box up'
            if (Cases[i + 1].Image == Box.Image || Cases[i + 1].Image == boxup.Image)
            {
                if (Cases[i + 2].Image == null)
                {
                    Cases[i + 2].Image = Box.Image;
                    Cases[i + 1].Image = player.Image;

                    if (goals.Contains(Cases[i]))
                        Cases[i].Image = goal.Image;

                    else
                        Cases[i].Image = null;
                }
                else
                
                if (Cases[i + 2].Image == goal.Image)
                {
                    Cases[i + 2].Image = boxup.Image;
                    Cases[i + 1].Image = player.Image;

                    if (goals.Contains(Cases[i]))

                        Cases[i].Image = goal.Image;

                    else
                        Cases[i].Image = null;
                }

            }
            movecount++;
            label10.Text = movecount.ToString();
        }

        //left 
        void Move_left(int i)
        {

            //if cases[i-l].image is a 'wall' player can't move


            // if cases[i-l].image is a 'goal' or null platayer can mvoe
            //case if it 'null'

            if (Cases[i - 1].Image == goal.Image || Cases[i - 1].Image == null)
            {
                Cases[i - 1].Image = player.Image;

                if (goals.Contains(Cases[i]))
                {
                    Cases[i].Image = goal.Image;
                }
                else
                {
                    Cases[i].Image = null;
                }
            }

            //case if it 'box'
            if (Cases[i - 1].Image == Box.Image || Cases[i - 1].Image == boxup.Image)
            {
                if (Cases[i - 2].Image == null)
                {
                    Cases[i - 2].Image = Box.Image;
                    Cases[i - 1].Image = player.Image;

                    if (goals.Contains(Cases[i]))
                    {
                        Cases[i].Image = goal.Image;
                    }

                    else
                    {
                        Cases[i].Image = null;
                    }
                }
                else
                //case if it 'goal'
                if (Cases[i - 2].Image == goal.Image)
                {
                    Cases[i - 2].Image = boxup.Image;
                    Cases[i - 1].Image = player.Image;

                    if (goals.Contains(Cases[i]))

                        Cases[i].Image = goal.Image;

                    else
                        Cases[i].Image = null;
                }

            }
            movecount++;
            label10.Text = movecount.ToString();
        }

        //up

        void Move_up(int i)
        {

            if (Cases[i - 8].Image == null || Cases[i - 8].Image == goal.Image)
            {
                Cases[i - 8].Image = player.Image;
                if (goals.Contains(Cases[i]))
                    Cases[i].Image = goal.Image;
                else
                    Cases[i].Image = null;
            }
            else
                if (Cases[i - 8].Image == Box.Image || Cases[i - 8].Image == boxup.Image)
            {
                if (Cases[i - 16].Image == null)
                {
                    Cases[i - 16].Image = Box.Image;
                    Cases[i - 8].Image = player.Image;
                    if (goals.Contains(Cases[i]))
                        Cases[i].Image = goal.Image;
                    else
                        Cases[i].Image = null;
                }
                if (Cases[i - 16].Image == null)
                {
                    Cases[i - 16].Image = Box.Image;
                    Cases[i - 8].Image = player.Image;
                    if (goals.Contains(Cases[i]))
                        Cases[i].Image = goal.Image;
                    else
                        Cases[i].Image = null;
                }
                else
                    if (Cases[i - 16].Image == goal.Image)
                {
                    Cases[i - 16].Image = boxup.Image;
                    Cases[i - 8].Image = player.Image;
                    if (goals.Contains(Cases[i]))
                        Cases[i].Image = goal.Image;
                    else
                        Cases[i].Image = null;
                }

            }
            movecount++;
            label10.Text = movecount.ToString();
        }

        //Down
        void Move_Down(int i)
        {


            if (Cases[i + 8].Image == null || Cases[i + 8].Image == goal.Image)
            {
                Cases[i + 8].Image = player.Image;
                if (goals.Contains(Cases[i]))
                    Cases[i].Image = goal.Image;
                else
                    Cases[i].Image = null;
            }
            else
                if (Cases[i + 8].Image == Box.Image || Cases[i + 8].Image == boxup.Image)
            {
                if (Cases[i + 16].Image == null)
                {
                    Cases[i + 16].Image = Box.Image;
                    Cases[i + 8].Image = player.Image;
                    if (goals.Contains(Cases[i]))
                        Cases[i].Image = goal.Image;
                    else
                        Cases[i].Image = null;
                }
                if (Cases[i + 16].Image == null)
                {
                    Cases[i + 16].Image = Box.Image;
                    Cases[i + 8].Image = player.Image;
                    if (goals.Contains(Cases[i]))
                        Cases[i].Image = goal.Image;
                    else
                        Cases[i].Image = null;
                }
                else
                    if (Cases[i + 16].Image == goal.Image)
                {
                    Cases[i + 16].Image = boxup.Image;
                    Cases[i + 8].Image = player.Image;
                    if (goals.Contains(Cases[i]))
                        Cases[i].Image = goal.Image;
                    else
                        Cases[i].Image = null;
                }

            }
            movecount++;
            label10.Text = movecount.ToString();

        }

        //adding comtroles
        // lable cilke  up
        private void label2_Click(object sender, EventArgs e)
        {
            //move up
            Move_up(Position());
            win();
        }
        
        // lable clike down
        private void label4_Click(object sender, EventArgs e)
        {
            //move down
            Move_Down(Position());
            win();
        }

        // lable laft 
        private void label1_Click(object sender, EventArgs e)
        {
            //move left 
            Move_left(Position());
            win();
        }

        // lable right 
        private void label3_Click(object sender, EventArgs e)
        {
            //move Right
            Move_Right(Position());
            win();
        }

        private void down(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Left)
            {
                Move_left(Position());
                win();
            }
            if (e.KeyCode == Keys.Right)
            {
                Move_Right(Position());
                win();
            }
            if (e.KeyCode == Keys.Up)
            {
                Move_up(Position());
                win();
            }
            if (e.KeyCode == Keys.Down)
            {
                Move_Down(Position());
                win();
            }

        }

        //check win 
        public void win()
        {   //if all the goales are boxup it stats win
            // if (Box.Image == null)
            for (int i = 0; i < Cases.Length; i++)
                if (Cases[i].Image == Box.Image)
                {
                    pic = true;
                    break;
                }
                else
                    pic = false;


            if (pic == false)
            {
                DialogResult DR = MessageBox.Show("you win", "whant to play next leval ? ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DR == DialogResult.Yes && next_Leval == 5)

                {
                    message("title acheived sokobon master","Game complite");
                    this.Close();
                }
                else if (DR == DialogResult.Yes)
                {
                    nextLeval();
                }

            }



            /* if (goals[0].Image == boxup.Image && goals[1].Image == boxup.Image && goals[2].Image == boxup.Image && goals[3].Image == boxup.Image && goals[4].Image == boxup.Image && goals[5].Image == boxup.Image && goals[6].Image == boxup.Image && goals[7].Image == boxup.Image && goals[8].Image == boxup.Image)

            {
                DialogResult DR = MessageBox.Show("you win", "whant to play next leval ? ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DR == DialogResult.Yes && next_Leval == 6)
                {

                    string message = "sorry !!";
                    string title = "no levals";
                    MessageBox.Show(message, title);
                    this.Close();

                }
                if(DR == DialogResult.Yes)
                {
                    nextLeval();
                }
                else
                    // close the application
                    this.Close();
            }
         */

        }

        //restaet lable 
        private void Restart_Click(object sender, EventArgs e)
        {
            restart();
            // restart_leval = true;
        }

         
        
        public void restart()
        {
            movecount = 0;
            object obj = new object();
            EventArgs e = new EventArgs();
            Form1_Load(obj, e);
        }
     
        //next leval 
        public void nextLeval()
        {
            next_Leval++;
            object obj = new object();
            EventArgs e = new EventArgs();
            Form1_Load(obj, e);

        }

        public void Leval1()
        {
            foreach (PictureBox c in Cases)
            {
                if (c.Image == player.Image || c.Image == Box.Image || c.Image == boxup.Image || c.Image == goal.Image || c.Image == wall.Image)
                    c.Image = null;
                movecount = 0;
            }
            // 
            goals = new List<PictureBox>();
            c51.Image = player.Image;
            c18.Image = c19.Image = c20.Image = c21.Image = goal.Image;
            goals.AddRange(new PictureBox[] { c18, c19, c20, c21 });
            c42.Image = c43.Image = c44.Image = c45.Image = Box.Image;
            //movecount = 0;
            label10.Text = movecount.ToString();

        }
        public void Leval2()
        {
            //to delete all imaage before started
            foreach (PictureBox c in Cases)
            {
                if (c.Image == player.Image || c.Image == Box.Image || c.Image == boxup.Image || c.Image == goal.Image || c.Image == wall.Image)
                    c.Image = null;
                movecount = 0;
            }
            goals = new List<PictureBox>();
            c51.Image = player.Image;
            c11.Image = c12.Image = c30.Image = c38.Image = goal.Image;
            goals.AddRange(new PictureBox[] { c12, c11, c30, c38 });
            c28.Image = c35.Image = c45.Image = c44.Image = Box.Image;
            c33.Image = c25.Image = c17.Image = c18.Image = c9.Image = c10.Image = c13.Image = c14.Image = c21.Image = c22.Image = c43.Image = wall.Image;
            // movecount = 0;
            label10.Text = movecount.ToString();
        }
        public void Leval3()
        {
            foreach (PictureBox C in Cases)
            {
                if (C.Image == player.Image || C.Image == Box.Image || C.Image == boxup.Image || C.Image == wall.Image || C.Image == goal.Image)
                    C.Image = null;
                movecount = 0;
            }
            goals = new List<PictureBox>();
            c51.Image = player.Image;
            // label2.Text = Position().ToString();
            c17.Image = c18.Image = c33.Image = c34.Image = c35.Image = wall.Image;
            c9.Image = c10.Image = c41.Image = c42.Image = goal.Image;
            goals.AddRange(new PictureBox[] { c9, c10, c41, c42 });
            c20.Image = c12.Image = c43.Image = c45.Image = Box.Image;
            //movecount = 0;
            label5.Text = movecount.ToString();
        }
        public void Leval4()
        {
            foreach (PictureBox C in Cases)
            {
                if (C.Image == player.Image || C.Image == Box.Image || C.Image == boxup.Image || C.Image == goal.Image || C.Image == wall.Image)
                    C.Image = null;
                movecount = 0;
            }
            goals = new List<PictureBox>();
            c51.Image = player.Image;
            // label2.Text = Position().ToString();
            c27.Image = c28.Image = c35.Image = c34.Image = c36.Image = wall.Image;
            c42.Image = c44.Image = c29.Image = c18.Image = goal.Image;
            goals.AddRange(new PictureBox[] { c42, c44, c18, c29 });
            c43.Image = c19.Image = c21.Image = c45.Image = Box.Image;
            // movecount = 0;
            label5.Text = movecount.ToString();
        }
        public void Leval5()
        {
            foreach (PictureBox C in Cases)
            {
                if (C.Image == player.Image || C.Image == Box.Image || C.Image == boxup.Image || C.Image == goal.Image || C.Image == wall.Image)
                    C.Image = null;
                movecount = 0;
            }
            goals = new List<PictureBox>();
            c38.Image = player.Image;
            // label2.Text = Position().ToString();
            c20.Image = c52.Image = wall.Image;
            c10.Image = c11.Image = c13.Image = c14.Image = c18.Image = c19.Image = c21.Image = c22.Image = goal.Image;
            goals.AddRange(new PictureBox[] { c10, c11, c13, c24, c14, c18, c19, c21, c22 });
            c27.Image = c12.Image = c28.Image = c29.Image = c36.Image = c43.Image = c44.Image = c45.Image = Box.Image;
            // movecount = 0;
            label5.Text = movecount.ToString();
        }

        private void label12_MouseClick(object sender, MouseEventArgs e)
        {
            nextLeval();
        }

        private void label13_MouseClick(object sender, MouseEventArgs e)
        {
            if (movecount <= 1)
            {
                next_Leval--;
                restart();
            }

        }

        static void message(string message , string title)
        {
           
            MessageBox.Show(message, title);

        }
    }

 }

    

 
