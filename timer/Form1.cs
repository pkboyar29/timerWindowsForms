using System;
using System.Windows.Forms;

namespace timer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int h, m, s;
        bool f_start;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (h != 0 || m != 0 || s != 0)
            {
                if (m < 60 && s < 60)
                {
                    label3.Text = "";
                    s = s - 1;
                    if (s == -1)
                    {
                        m = m - 1;
                        s = 59;
                    }
                    if (m == -1)
                    {
                        h = h - 1;
                        m = 59;
                    }
                    if (h == 0 && m == 0 && s == 0)
                    {
                        timer1.Stop();
                        label1.Text = "00:00:00";
                        f_start = false;
                        MessageBox.Show("Время вышло!");
                    }
                    if (h < 10) label1.Text = "0" + h.ToString();
                    else label1.Text = h.ToString();
                    if (m < 10) label1.Text = label1.Text + ":" + "0" + m.ToString();
                    else label1.Text = label1.Text + ":" + m.ToString();
                    if (s < 10) label1.Text = label1.Text + ":" + "0" + s.ToString();
                    else label1.Text = label1.Text + ":" + s.ToString();
                }
                else
                {
                    label3.Text = "Некоректный ввод данных";
                }
            }
            else
            {
                timer1.Stop();
                f_start = false;
                MessageBox.Show("Время вышло!");
            }
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            label5.Text = DateTime.Now.ToString("T");
        }
        private void button1_Click(object sender, EventArgs e)
        {
            f_start = true;
            button2.Text = "Остановить";
            try
            {
                h = Convert.ToInt32(textBox1.Text);
                m = Convert.ToInt32(textBox2.Text);
                s = Convert.ToInt32(textBox3.Text);
                if (h > 23)
                {
                    h = 23;
                    textBox1.Text = "23";
                }
                if (m > 59)
                {
                    m = 59;
                    textBox2.Text = "59";
                }
                if (s > 59)
                {
                    s = 59;
                    textBox3.Text = "59";
                }
                if (h < 10) label1.Text = "0" + h.ToString();
                else label1.Text = h.ToString();
                if (m < 10) label1.Text = label1.Text + ":" + "0" + m.ToString();
                else label1.Text = label1.Text + ":" + m.ToString();
                if (s < 10) label1.Text = label1.Text + ":" + "0" + s.ToString();
                else label1.Text = label1.Text + ":" + s.ToString();
                timer1.Start();
            }
            catch (Exception)
            {
                label3.Text = "Неправильный ввод данных";
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (f_start)
            {
                if (timer1.Enabled)
                {
                    button2.Text = "Возобновить";
                    timer1.Enabled = false;
                }
                else
                {
                    button2.Text = "Остановить";
                    timer1.Enabled = true;
                }
            }
        }

        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.SelectAll();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            f_start = false;
            button2.Text = "Остановить";
            label1.Text = "00:00:00";
            label3.Text = "";
            textBox1.Text = "0";
            textBox2.Text = "0";
            textBox3.Text = "0";
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8)
            {
                e.Handled = true;
            }
        }
    }
}
