using System;
using System.Windows.Forms;
using NetMQ;
using NetMQ.Sockets;

namespace PublisherWindowsFormsApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonPublish_Click(object sender, EventArgs e)
        {
            using (var publisher = new PublisherSocket())
            {
                publisher.Bind("tcp://127.0.0.1:8888");

                publisher
                    .SendMoreFrame("COMMAND")
                    .SendFrame(textBoxCommand.Text);
            }
        }
    }
}
