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

            var user1 = new User("Hans", Gender.Male, 1.77, DateTime.Today);
            var user2 = new User("Sara", Gender.Male, 1.72, DateTime.Today.AddDays(-10));
            var user3 = new User("Hans", Gender.Male, 1.66, DateTime.Today.AddDays(2));
            Users.Add(user1);
            Users.Add(user2);
            Users.Add(user3);
        }

        private void AddUserButton_Click(object sender, EventArgs e)
        {
            var user = new User(nameTextBox.Text, (Gender)Enum.Parse(typeof(Gender), genderTextBox.Text), double.Parse(heightTextBox.Text), DateTime.Parse(birthdayDateTimePicker.Text));
            Users.Add(user);
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.V && e.Control)
            {
                char[] rowSplitter = { '\r', '\n' };
                char[] columnSplitter = { '\t' };

                //get the text from clipboard
                IDataObject dataInClipboard = Clipboard.GetDataObject();
                string stringInClipboard = (string)dataInClipboard.GetData(DataFormats.Text);
                //split it into lines
                string[] rowsInClipboard = stringInClipboard.Split(rowSplitter, StringSplitOptions.RemoveEmptyEntries);
                //get the row and column of selected cell in grid
                int r = dataGridView1.SelectedCells[0].RowIndex;

                int c = dataGridView1.SelectedCells[0].ColumnIndex;

                //add rows into dataGridView1 to fit clipboard lines

                if (dataGridView1.Rows.Count < (r + rowsInClipboard.Length))
                {
                    dataGridView1.Rows.Add(r + rowsInClipboard.Length - dataGridView1.Rows.Count);
                }

                // loop through the lines, split them into cells and place the values in the corresponding cell.
                for (int iRow = 0; iRow < rowsInClipboard.Length; iRow++)
                {
                    //split row into cell values
                    string[] valuesInRow = rowsInClipboard[iRow].Split(columnSplitter);
                    //cycle through cell values
                    for (int iCol = 0; iCol < valuesInRow.Length; iCol++)
                    {
                        //assign cell value, only if it within columns of the grid
                        if (dataGridView1.ColumnCount - 1 >= c + iCol)
                        {
                            dataGridView1.Rows[r + iRow].Cells[c + iCol].Value = valuesInRow[iCol];
                        }

                    }
                }
            }
        }
    }
}
