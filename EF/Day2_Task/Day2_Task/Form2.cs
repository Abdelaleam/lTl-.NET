using Day2_Task.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Day2_Task.Data;
using Day2_Task.Models;

namespace Day2_Task
{
    public partial class Form2 : Form
    {
        object Screenings = new object();
        public Form2(object Screenings)
        {
            InitializeComponent();
            this.Screenings = Screenings;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Screenings;

        }
    }
}
