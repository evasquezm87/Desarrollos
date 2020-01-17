using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
using Newtonsoft.Json;

namespace WinFormsConsumeAPI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            string respuesta = await GetHttp();
            List<PostViewModel> lst = JsonConvert.DeserializeObject<List<PostViewModel>>(respuesta);
            dgv1.DataSource = lst;

        }

        string url = "https://jsonplaceholder.typicode.com/posts";
        public async Task<string> GetHttp()
        {
            WebRequest oRequest = WebRequest.Create(url);
            WebResponse oResponse = oRequest.GetResponse();
            StreamReader sr = new StreamReader(oResponse.GetResponseStream());

            return await sr.ReadToEndAsync();

        }


    }

    public class PostViewModel
    {
        public string userId { get; set; }
        public string id { get; set; }
        public string title { get; set; }
        public string body { get; set; }
    }
}
