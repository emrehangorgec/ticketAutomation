﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ticketAutomation.Helpers;
using ticketAutomation.Models;

namespace ticketAutomation
{
    public partial class Booking : Form
    {
        public Booking()
        {
            InitializeComponent();
        }
        List<Movie> movies;
        DateTime currentDate = DateTime.Now;
        DateTime useDate;
        Form2 form2;


        private void Form1_Load(object sender, EventArgs e)
        {
            useDate = currentDate;
            labelDate.Text = useDate.ToShortDateString();    
            movies = Helper.CreateMovies();
            ListControls();
            form2 = new Form2(movies,this);
        }
        private void ListControls()
        {
            Size pictureSize = new Size(200, 180);
            Size buttonSize = new Size(90, 40);
            int x = 50; int y = 100;
            int xIncrement = 400;
            int yIncrement = 300;
            for (int i = 0; i < movies.Count; i++)
            {
                PictureBox picture = new PictureBox();
                picture.Location = new Point(x, y);
                picture.Size = pictureSize;
                picture.Image = Image.FromFile(movies[i].picturePath);
                picture.Image = Image.FromFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, movies[i].picturePath));

                picture.SizeMode = PictureBoxSizeMode.StretchImage;
                this.Controls.Add(picture);
                
                //Button
                int buttonX = x;
                int buttonY = picture.Bottom + 10;
                for(int index = 0; index < 3; index++)
                {
                    Button button = new Button();
                    button.Text = movies[i].sessions[index].time;
                    button.Location = new Point(buttonX, buttonY);
                    button.Size = buttonSize;
                    button.Tag = i; //index of the movie
                    button.Click += new EventHandler(button_Click);
                    this.Controls.Add(button);
                    buttonX += 100;
                }
                if (1200 > x + xIncrement + picture.Width)
                {
                    x += xIncrement;
                }
                else
                {
                    x = 50; 
                    y += yIncrement;
                }
            }
        }

        private void button_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            int movieIndex = Convert.ToInt32(button.Tag);
            string sessionTime = button.Text;
            string sessionDate = labelDate.Text;
            if(DateTime.Parse($"{sessionDate} {sessionTime}") < DateTime.Now)
            {
                MessageBox.Show("You have missed the selected session.\nPlease choose another one.");
                return;
            }
            this.Hide();
            form2.Show();
            form2.ListDetail(movieIndex,sessionTime,sessionDate);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            useDate = useDate.AddDays(-1);
            labelDate.Text = useDate.ToShortDateString();
            buttonNext.Enabled = true;
            if(currentDate == useDate)
            {
                buttonPrevious.Enabled = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            useDate = useDate.AddDays(1);
            labelDate.Text = useDate.ToShortDateString();
            buttonPrevious.Enabled = true;
            if (currentDate.AddDays(2) == useDate)
            {
                buttonNext.Enabled = false;
            }
        }
    }
}
