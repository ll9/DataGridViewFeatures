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
        public BindingList<User> Users { get; set; }

        public Form1()
        {
            InitializeComponent();
        }
    }
}
