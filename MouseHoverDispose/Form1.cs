﻿using System;
using System.Drawing;
using System.Windows.Forms;

namespace MouseHoverDispose
{
    public partial class Form1 : Form
    {
        public int Count { get; set; }
        public Form1()
        {
            InitializeComponent();
        }

        private void Btn1_Dispose_MouseHover(object sender, EventArgs e)
        {
            if (sender is Button btn)
            {
                btn.Dispose();
                Count++;
                Lbl1_Count.Text = $"Count: {Count}";
                Random random = new Random();
                int randX = random.Next(0, Width - Btn1_Dispose.Width);
                int randY = random.Next(0, Height - Btn1_Dispose.Height * 2);
                Button button = new Button()
                {
                    Size = Btn1_Dispose.Size,
                    Location = new Point(randX, randY),
                    Text = Btn1_Dispose.Text,
                    Font = Btn1_Dispose.Font,
                    BackColor = Btn1_Dispose.BackColor,
                };
                button.MouseHover += Btn1_Dispose_MouseHover;
                Controls.Add(button);

                if (Count == 10)
                {
                    MessageBox.Show("Game over!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    var dialog = MessageBox.Show("Do you want to try again ?", "Info", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialog == DialogResult.Yes)
                    {
                        Count = 0;
                        Lbl1_Count.Text = $"Count: {Count}";
                    }
                    else Application.Exit();
                }
            }
        }
    }
}
