using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using Model;

namespace FormsApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public List<IThreeDimensional> List = new List<IThreeDimensional>();

        public void AddToList(IThreeDimensional item)
        {
            List.Add(item);
            dataGridView1.Rows.Add(item.Name, item.Volume, item.ToString());
        }

        public void FindDiscount(string what, double from, double to)
        {
            dataGridView1.Rows.Clear();
            foreach (IThreeDimensional item in List)
            {
                if (item.Name == what && item.Volume >= from && item.Volume <= to)
                {
                    dataGridView1.Rows.Add(item.Name, item.Volume, item.ToString());
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddFrm addForm = new AddFrm(this);
            addForm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                List.RemoveAt(dataGridView1.SelectedRows[0].Index);
                dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
            }
            catch (Exception)
            {
                MessageBox.Show("Выберите данные!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();

            int choose = rnd.Next(3);

            switch (choose)
            {
                case 0:
                    AddToList(new Ball(rnd.Next(1, 100000)));
                    break;
                case 1:
                    AddToList(new Pyramid(rnd.Next(1, 100000), rnd.Next(1, 100000)));
                    break;
                case 2:
                    var type = rnd.Next(1, 3);
                    AddToList(new Parallelepiped(rnd.Next(1, 1000000)));
                    break;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (saveFileDialog1.ShowDialog() != DialogResult.OK) return;

                FileStream file = File.Create(saveFileDialog1.FileName);
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(file, List);
                file.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (openFileDialog1.ShowDialog() != DialogResult.OK) return;

                FileStream file = File.OpenRead(openFileDialog1.FileName);
                BinaryFormatter formatter = new BinaryFormatter();
                IList<IThreeDimensional> deserialize = formatter.Deserialize(file) as IList<IThreeDimensional>;

                List.Clear();
                dataGridView1.Rows.Clear();

                if (deserialize != null)
                {
                    foreach (var item in deserialize)
                    {
                        AddToList(item);
                    }
                }

                file.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            FindFrm searchForm = new FindFrm(this);
            searchForm.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            foreach (var item in List)
            {
                dataGridView1.Rows.Add(item.Name, item.Volume, item.ToString());
            }
        }
    }
}
