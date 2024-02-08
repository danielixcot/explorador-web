using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Web.WebView2.Core;

namespace explorador_web
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Resize += new System.EventHandler(this.Form_Resize);
        }

        private void Form_Resize(object sender, EventArgs e)
        {
            webView21.Size = this.ClientSize - new System.Drawing.Size(webView21.Location);
            button1.Left = this.ClientSize.Width - button1.Width;
            comboBox1.Width = button1.Left - comboBox1.Left;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string url = comboBox1.Text.ToString();
            if (url.Contains(".") || url.Contains("/") || url.Contains(":"))
            {
                if (url.Contains("https"))
                    webView21.CoreWebView2.Navigate(url);
                else
                {
                    url = "https://" + url;
                    webView21.CoreWebView2.Navigate(url);
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(url))
                {
                    url = "https://www.google.com/search?q=" + url;
                    webView21.CoreWebView2.Navigate(url);
                }
            }
        }

        private void inicioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webView21.CoreWebView2.Navigate("https://www.bing.com");
        }

        private void haciaAtrasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webView21.CoreWebView2.GoBack();
        }

        private void haciaAdelanteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webView21.CoreWebView2.GoForward();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            //webView21.CoreWebView2.Navigate("https://www.microsoft.com");
        }
    }
}
