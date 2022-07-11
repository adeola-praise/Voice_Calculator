﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Voice_Calculator
{
    public partial class Limits : Form
    {
        public Limits()
        {
            InitializeComponent();
        }

        private void Limits_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(100, 149, 237);
        }

        private void SecondNextBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form2 = new Instructions();
            form2.Closed += (s, args) => this.Close();
            form2.Show();
        }
    }
}
