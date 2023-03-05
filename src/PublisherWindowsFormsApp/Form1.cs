using System;
using System.Windows.Forms;
using NetMQ;
using NetMQ.Sockets;

namespace PublisherWindowsFormsApp
{
    public partial class Form1 : Form
    {
        private readonly PublisherSocket publisher = new PublisherSocket();
        public Form1()
        {
            publisher.Bind("tcp://127.0.0.1:8888");
            InitializeComponent();
        }

        private void buttonPublish_Click(object sender, EventArgs e)
        {
            publisher
                    .SendMoreFrame("COMMAND")
                    .SendFrame(textBoxCommand.Text);
        }
    }
}
