using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LearningProjectsForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string result = CommonHelper.HttpPostWebService("http://localhost:5000/StudentService.asmx", "<strInput>192.168.1.100</strInput>");
            MessageBox.Show(result);
        }
    }
}
