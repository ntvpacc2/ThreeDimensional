using System;
using System.Windows.Forms;

namespace FormsApp
{
    public partial class FindFrm : Form
    {
        private readonly Form1 _frm;

        public FindFrm(Form1 frm)
        {
            _frm = frm;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                _frm.FindDiscount(radioButton1.Checked ? radioButton1.Text : radioButton2.Text,
                    double.Parse(textBox1.Text), double.Parse(textBox2.Text));
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8 && number != 44 && number != '-')
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8 && number != 44 && number != '-')
            {
                e.Handled = true;
            }
        }
    }
}
