﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private bool goLeft, goRight, jumping, isGameOver;

        private int jumpSpeed;
        private int force;
        public static int score = 0;
       
        private int playerSpeed = 7;
        public static int time = 0;


        private int horizontalSpeed = 5;
        private int verticalSpeed = 3;

        private int enemyOneSpeed = 3;
        private int enemyTwoSpeed = 1;
        private int sawSpeed = 3;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void player_Click(object sender, EventArgs e)
        {

        }

        private void MainGameTimerEvent(object sender, EventArgs e)
        {
            txtScore.Text = "X " + score;
            player.Top += jumpSpeed;

            if (goLeft == true)
            {
                player.Left -= playerSpeed;
            }
            if (goRight == true)
            {
                player.Left += playerSpeed;
            }
            if (jumping == true && force < 0)
            {
                jumping = false;
            }
            if (jumping == true)
            {
                jumpSpeed = -8;
                player.Image = WindowsFormsApp1.Properties.Resources.jumping; 
                force -= 1;
            }
            else
            {
                jumpSpeed = 10;
                player.Image = WindowsFormsApp1.Properties.Resources.player;

            }
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox)
                {
                    if ((string)x.Tag == "platform")
                    {

                        if (player.Bounds.IntersectsWith(x.Bounds))
                        {
                            force = 8;
                            player.Top = x.Top - player.Height;

                            if((string)x.Name== "horizontalPlatform" && goLeft == false&& goRight ==false)
                            {
                                player.Left -= horizontalSpeed; 

                            }
                        }
                        x.BringToFront();

                    }



                    if ((string)x.Tag == "coin")
                    {
                        if (player.Bounds.IntersectsWith(x.Bounds) && x.Visible == true)
                        {
                            x.Visible = false;
                            score++;
                        }
                    }

                    if ((string)x.Tag == "enemy")
                    {
                        if (player.Bounds.IntersectsWith(x.Bounds))
                        {
                            player.Image = WindowsFormsApp1.Properties.Resources.dead;

                            gameTimer.Stop();
                            ScoreTimer.Stop();
                            isGameOver = true;
                            txtScore.Text = "X " + score + Environment.NewLine + Environment.NewLine + "You were killed in your journey!!";
                        }
                    }
                }
            }

            horizontalPlatform.Left -= horizontalSpeed;
            if (horizontalPlatform.Left < 0 || horizontalPlatform.Left + horizontalPlatform.Width > this.ClientSize.Width)
            {
                horizontalSpeed = -horizontalSpeed;
            }
            verticalPlatform.Top += verticalSpeed;
            if (verticalPlatform.Top < 195 || verticalPlatform.Top > 451)
            {
                verticalSpeed = -verticalSpeed;
            }

            enemyOne.Left -= enemyOneSpeed; 
            if (enemyOne.Left < pictureBox4.Left|| enemyOne.Left + enemyOne.Width > pictureBox4.Left + pictureBox4.Width)
            {
                enemyOneSpeed = -enemyOneSpeed;

            }


            saw.Left -= sawSpeed;
            if (saw.Left < pictureBox7.Left || saw.Left + saw.Width > pictureBox7.Left + pictureBox7.Width)
            {
                sawSpeed = -sawSpeed;

            }

            enemyTwo.Left -= enemyTwoSpeed;
            if (enemyTwo.Left < pictureBox5.Left || enemyTwo.Left + enemyTwo.Width > pictureBox5.Left + pictureBox5.Width)
            {
                enemyTwoSpeed = -enemyTwoSpeed;

            }

            if(player.Top + player.Height > this.ClientSize.Height + 50)
            {
                gameTimer.Stop();
                ScoreTimer.Stop();
                isGameOver = true;
                txtScore.Text = "X " + score + Environment.NewLine + Environment.NewLine + "You fell to your death!"; 
            }
            if (player.Bounds.IntersectsWith(door.Bounds) && score == 12)
            {
                gameTimer.Stop(); 
                Form2 level2 = new Form2();
                level2.Show();
                this.Hide();

            }

            if (score < 12)
            {
                door.Image = WindowsFormsApp1.Properties.Resources.platformPack_tile049; 

            }
            else
            {
                door.Image = WindowsFormsApp1.Properties.Resources.platformPack_tile048;
            }


        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void horizontalPlatform_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void ScoreTimer_Tick(object sender, EventArgs e)
        {
            time += 1;
            txtTime.Text =  time.ToString();

        }

        private void pictureBox21_Click(object sender, EventArgs e)
        {

        }

        private void enemyOne_Click(object sender, EventArgs e)
        {

        }

        private void enemyTwo_Click(object sender, EventArgs e)
        {

        }

        private void door_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {

        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            { 
                goLeft = true;
            }
            if (e.KeyCode == Keys.Right)
            {
                goRight = true;
            }
            if (e.KeyCode == Keys.Space && jumping ==false)
            {
                jumping = true;
            }

        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Left)
            {
                goLeft = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                goRight = false;
            }

            if (jumping == true)
            {
                jumping = false; 
            }

            if (e.KeyCode == Keys.Enter && isGameOver == true)
            {
                RestartGame(); 
            }



        }
        private void RestartGame()
        {
            jumping = false;
            goLeft = false;
            goRight = false; 
            isGameOver = false;
            score = 0;
            player.Image = WindowsFormsApp1.Properties.Resources.player;


            txtScore.Text = "X "+score;

            foreach (Control x in this.Controls) 
            { 
                if (x is PictureBox && x.Visible == false)
                {
                    x.Visible = true; 
                }
            }

            //reset posisiton of platform and enemeines 

            player.Left = 27;
            player.Top = 434;

            enemyOne.Left = 227;

            enemyTwo.Left = 21;

            horizontalPlatform.Left = 167;
            verticalPlatform.Top = 450; 

            gameTimer.Start();
            ScoreTimer.Start(); 


        }
    }
}
