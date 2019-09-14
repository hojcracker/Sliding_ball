using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Slide_down
{
    public partial class Ball_sliding : Form
    {
        public Ball_sliding()
        {
            InitializeComponent();
        }

        private void BunifuThinButton21_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void Angle_TextChanged(object sender, EventArgs e)
        {
            if (angle.Text == "")
            {
                angle.Text = "0";
            }
            try
            {
                double anglee = Convert.ToDouble(angle.Text);
            }
            catch (Exception ex)
            {
                angle.Text = "0";
                MessageBox.Show("Invalid input");
            }
        }

        private void Gravity_TextChanged(object sender, EventArgs e)
        {
            if (gravity.Text == "")
            {
                gravity.Text = "0";
            }
            try
            {
                double gravityy = Convert.ToDouble(gravity.Text);
            }
            catch (Exception ex)
            {
                gravity.Text = "0";
                MessageBox.Show("Invalid input");
            }
        }

        private void Length_TextChanged(object sender, EventArgs e)
        {
            if (length.Text == "")
            {
                length.Text = "0";
            }
            try
            {
                double lengthh = Convert.ToDouble(length.Text);
            }
            catch (Exception ex)
            {
                length.Text = "0";
                MessageBox.Show("Invalid input");
            }
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            if (time.Text == "")
            {
                time.Text = "0";
            }
            try
            {
                double timee = Convert.ToDouble(time.Text);
            }
            catch (Exception ex)
            {
                time.Text = "0";
                MessageBox.Show("Invalid input");
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            for (int i = 12; i < 350; i++)
            {
                ball.Location = new Point(i,ball.Location.Y);
            }
            ball.Location = new Point(12, ball.Location.Y);
            if (variables.SelectedIndex == 0)
            {
                double gravity_force = Convert.ToDouble(gravity.Text);
                double slope_length = Convert.ToDouble(length.Text);
                double seconds = Convert.ToDouble(time.Text);
                double slope_angle = (2 * slope_length) / (gravity_force * Math.Pow(seconds, 2));
                angle.Text = Convert.ToString(slope_length);
            }
            if (variables.SelectedIndex == 1)
            {
                double slope_angle = Convert.ToDouble(angle.Text);
                double slope_length = Convert.ToDouble(length.Text);
                double seconds = Convert.ToDouble(time.Text);
                double gravity_force = (2 * slope_length) / (Math.Sin(slope_angle) * Math.Pow(seconds, 2));
                gravity.Text = Convert.ToString(gravity_force);
            }
            if (variables.SelectedIndex == 2)
            {
                double slope_angle = Convert.ToDouble(angle.Text);
                double gravity_force = Convert.ToDouble(gravity.Text);
                double acceleration = Math.Sin(slope_angle) * gravity_force;
                double seconds = Convert.ToDouble(time.Text);
                double slope_length = acceleration * Math.Pow(seconds, 2);
                length.Text = Convert.ToString(slope_length);
            }
            if (variables.SelectedIndex == 3)
            {
                double slope_angle = Convert.ToDouble(angle.Text);
                double gravity_force = Convert.ToDouble(gravity.Text);
                double slope_length = Convert.ToDouble(length.Text);
                double acceleration = Math.Sin(slope_angle) * gravity_force;
                double seconds = Math.Sqrt((2 * slope_length) / acceleration);
                time.Text = Convert.ToString(seconds);
            }
        }

        private void Panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }
        Point lastPoint;
        private void Panel1_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }
    }
}
