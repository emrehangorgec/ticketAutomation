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
        public Form2(List<Movie> _movies, Booking _form1)
        {
            InitializeComponent();
            movies = _movies;
            form1 = _form1;

        }
        List<Movie> movies;
        Booking form1;
        Movie selectedMovie;
        Session selectedSession;
        public void ListDetail(int movieIndex, string _time, string _date)
        {
            selectedMovie = movies[movieIndex];
            selectedSession = selectedMovie.sessions.Find(s => s.date == _date && s.time == _time);
            labelTime.Text = $"{_date} - {_time}";
            labelMinute.Text = selectedMovie.minute;
            labelPrice.Text = selectedMovie.price.ToString();
            pictureBox1.Image = Image.FromFile(selectedMovie.picturePath);
            labelCategory.Text = selectedMovie.category.ToString();
            CheckSeatStatus();
        }
        private void CheckSeatStatus()
        {
            foreach (Control item in groupSeats.Controls)
            {
                if (item is Button)
                {
                    string row = item.Tag.ToString();
                    string number = item.Text;
                    item.Enabled = true;
                    foreach (Seats seat in selectedSession.seats)
                    {
                        if (seat.row == row && seat.number == number)
                        {
                            if (seat.status)
                            {
                                item.BackColor = Color.DarkRed;
                                item.Enabled = false;
                            }
                            else
                            {
                                item.BackColor = Color.Brown;
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
        List<Seats> seats = new List<Seats>();
        private void button24_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            string row = button.Tag.ToString();
            string number = button.Text;
            Seats seat = selectedSession.seats.Find(s => s.number == number && s.row == row);
            if (button.BackColor.Name != "Blue")
            {
                seats.Add(seat);
                button.BackColor = Color.Blue;
            }
            else
            {
                seats.Remove(seat);
                button.BackColor = Color.LightGreen;
            }
        }

        private void buttonbuy_Click(object sender, EventArgs e)
        {
            if (seats.Count == 0)
            {
                MessageBox.Show("Please choose at least one seat.");
                return;
            }
            ticket ticket = new ticket();
            ticket.movieName = selectedMovie.movieName;
            ticket.count = seats.Count;
            ticket.sessionTime = $"{selectedSession.date} - {selectedSession.time}";
            ticket.totalPrice = calculatePrice();
            foreach (Seats seat in seats)
            {
                seat.status = true;
            }
            MessageBox.Show(ticket.ToString());
            firstPage();
        }
        private void firstPage()
        {
            rSmall.Checked = false;
            rMedium.Checked = false;
            rLarge.Checked = false;
            seats.Clear();
            this.Hide();
            form1.Show();
        }
        private decimal calculatePrice()
        {
            decimal price = selectedMovie.price * seats.Count;
            if (rSmall.Checked)
            {
                price += 3;
            }
            else if (rMedium.Checked)
            {
                price += 6;
            }
            else if (rLarge.Checked)
            {
                price += 9;
            }
            return price;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            firstPage();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
