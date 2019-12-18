using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserMaintenance.Entities;

namespace UserMaintenance
{
    public partial class Form1 : Form
    {
        BindingList<User> users = new BindingList<User>();
        
        public Form1()
        {
            InitializeComponent();
            label1.Text = Resource1.FirstName; // label1
            label2.Text = Resource1.LastName;
            button1.Text = Resource1.Add; // button1
            button2.Text = Resource1.SaveFile; // button2


            // listbox1
            listBox1.DataSource = users;
            listBox1.ValueMember = "ID";
            listBox1.DisplayMember = "FullName";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var u = new User()
            {
                FullName = textBox1.Text,
            };
            users.Add(u);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.InitialDirectory = Application.StartupPath;
            sfd.AddExtension = true;
            sfd.DefaultExt = ".txt";
            if (sfd.ShowDialog() != DialogResult.OK)
            { return; }

            using (StreamWriter sw = new StreamWriter(sfd.FileName))
            {
                sw.WriteLine("Sorszám          Teljes név");
                int counter = 0;
                foreach (var u in users)
                {
                    sw.WriteLine(u.ID + " " + u.FullName);
                    counter++;
                }
            }
        }
    }
}
