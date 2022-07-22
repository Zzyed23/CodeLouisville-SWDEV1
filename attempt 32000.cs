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

namespace trynumber720000
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitBrowser();
        }
        public ChromiumWebBrowser browser;

        public ChromiumWebBrowser webbrowser;

        public void InitBrowser()
        {
            Cef.Initialize(new CefSettings());
            browser = new ChromiumWebBrowser("https://www.kayak.com/"); 
            this.Controls.Add(browser);

            browser.Dock = DockStyle.Fill;
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            browser.ExecuteScriptAsync("document.getElementById('keel-container form-container s-t-bp no-edges edges-s').value=" + '\'' +  + '\'');
            browser.ExecuteScriptAsync("document.getElementById('zEiP-formField zEiP-destination').value=" + '\'' +  + '\'');
            browser.ExecuteScriptAsync("document.getElementsByName('zEiP-formField zEiP-submit')[0].click()");
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
