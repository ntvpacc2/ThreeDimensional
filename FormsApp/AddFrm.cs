using System;
using System.Windows.Forms;
using Model;

namespace FormsApp
{
    public partial class AddFrm : Form
    {
        private readonly Form1 _frm;

        public AddFrm(Form1 frm)
        {
            _frm = frm;
            InitializeComponent();
        }

        private void radioButton1_CheckedChanged(object sender, System.EventArgs e)
        {
            label1.Text = "r";
            textBox2.Visible = false;
            label2.Text = "";
        }

        private void radioButton2_CheckedChanged(object sender, System.EventArgs e)
        {
            label1.Text = "s";
            textBox2.Visible = true;
            label2.Text = "h";
        }

        private void radioButton3_CheckedChanged(object sender, System.EventArgs e)
        {
            label1.Text = "a";
            textBox2.Visible = false;
            label2.Text = "";
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8 && number != 44 && number != '-')
            {
                e.Handled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (radioButton1.Checked)
                {
                    if (textBox1.Text != "")
                    {
                        _frm.AddToList(new Ball(double.Parse(textBox1.Text)));
                    }
                    else MessageBox.Show("Заполните все поля");
                }

                if (radioButton2.Checked)
                {
                    if (textBox1.Text != "" && textBox2.Text != "")
                    {
                        _frm.AddToList(new Pyramid(double.Parse(textBox1.Text), double.Parse(textBox2.Text)));
                    }
                    else MessageBox.Show("Заполните все поля");
                }

                if (radioButton3.Checked)
                {
                    if (textBox1.Text != "")
                    {
                        _frm.AddToList(new Parallelepiped(double.Parse(textBox1.Text)));
                    }
                    else MessageBox.Show("Заполните все поля");
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
    }
}
