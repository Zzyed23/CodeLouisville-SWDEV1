using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;

namespace FlightBot
{
    public partial class FlightBOT : Form
    {
        public FlightBOT()
        {
            InitializeComponent();
            WebBrowser.Navigate("https://www.google.com/travel/flights");
        }
        private void label1_Click(object sender, EventArgs e) //from**
        {
            
        }
        private void label2_Click(object sender, EventArgs e) //to**
        {

        }

        private void label3_Click(object sender, EventArgs e) //date1**
        {

        }
        private void label4_Click(object sender, EventArgs e) //date2**
        {

        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
