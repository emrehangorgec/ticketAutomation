using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ticketAutomation.Models;

namespace ticketAutomation
{
    public partial class Form2 : Form
    {
        public Form2(List<Movie> _movies, Form1 _form1)
        {
            InitializeComponent();
            movies = _movies;
            form1 = _form1;

        }
        List<Movie> movies;
        Form1 form1;
        Movie selectedMovie;
        Session selectedSession;
        public void ListDetail(int movieIndex, string time, string date)
        {
            selectedMovie = movies[movieIndex];
            selectedSession = selectedMovie.sessions.Find(session => session.date == date &&
            session.time == time);
            labelTime.Text = $"{date}- {time}";
            labelMinute.Text = selectedMovie.minute;
            labelPrice.Text = selectedMovie.price.ToString();
            pictureBox1.Image = Image.FromFile(selectedMovie.picturePath);
            labelCategory.Text = selectedMovie.category.ToString();
            checkSeatStatus();
        }
        private void checkSeatStatus()
        {
            foreach(Control item in groupSeats.Controls)
            {
                if(item is Button)
                {
                    string row = item.Tag.ToString();
                    string number = item.Text;
                    item.Enabled = true;
                    foreach (Seats seat  in selectedSession.seats)
                    {
                        if(seat.row ==row && seat.number == number)
                        {
                            if (seat.status)
                            {
                                item.BackColor= Color.DarkRed;
                                item.Enabled = false;
                            }
                            else
                            {
                                item.BackColor= Color.LightGreen;
                            }
                            break;
                        }

                    }
                }
            }

        }



        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button28_Click(object sender, EventArgs e)
        {

        }

        private void button22_Click(object sender, EventArgs e)
        {

        }

        private void button16_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
