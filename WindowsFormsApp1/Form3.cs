﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form3 : Form
    {
        int time = Form1.time; 

        public Form3()
        {
            InitializeComponent();
            txtTime.Text = "You finished in " + time + "S"; 
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 level1 = new Form1();
            level1.Show();
            this.Close();
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}