using DataGridViewFeatures.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataGridViewFeatures
{
    public partial class Form1 : Form
    {
        public BindingList<User> Users { get; set; } = new BindingList<User>();

        public Form1()
        {
            InitializeComponent();
            dataGridView1.DataSource = Users;
        }

        private void AddUserButton_Click(object sender, EventArgs e)
        {
            var user = new User(nameTextBox.Text, (Gender)Enum.Parse(typeof(Gender), genderTextBox.Text), double.Parse(heightTextBox.Text), DateTime.Parse(birthdayDateTimePicker.Text));
            Users.Add(user);
        }
    }
}
