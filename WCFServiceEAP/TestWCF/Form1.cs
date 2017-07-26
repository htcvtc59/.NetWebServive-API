using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestWCF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ServiceURI = "http://localhost:51834/Service1.svc/rest/GetMessage";
            HttpClient httpClient = new HttpClient();
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, ServiceURI);
            if (!string.IsNullOrEmpty(""))
            {
                request.Content = new StringContent("", Encoding.UTF8, "application/json");
            }
            HttpResponseMessage response = httpClient.SendAsync(request).Result;
            string returnString = response.Content.ReadAsStringAsync().Result;
            richTextBox1.AppendText(returnString);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ServiceWCF.Service1 client = new ServiceWCF.Service1();
            richTextBox1.Text = client.GetMessage();
        }
    }
}
