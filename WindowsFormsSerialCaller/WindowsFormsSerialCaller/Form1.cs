using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace WindowsFormsSerialCaller
{
    public partial class Form1 : Form
    {

        static SerialPort port;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Serial obj = new Serial();
            // obj.Some();
           // port.Close();
            label1.Text = "Ok";
            OpenPort();
            AddCaseForPort("1"); //1 to move forward
            port.Close();
            label3.Text = "Going forward";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label1.Text = "Ok";
            OpenPort();
            AddCaseForPort("2"); //2 to move backward
            port.Close();
            label3.Text = "Going Backward";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label1.Text = "Ok";
            OpenPort();
            AddCaseForPort("3"); //3 to Stop
            port.Close();
            label3.Text = "Stopped";

        }

        public void OpenPort()
        {
            
            string portNumber = "COM4";

            port = new SerialPort(portNumber, 9600);

            try //If the port is open
            {
                port.DataReceived += new SerialDataReceivedEventHandler(port_DataReceived);
                port.Open();

            }
            catch
            {
                label1.Text = "Can't Open port";
              
            }




        }

        public void AddCaseForPort(string case_forPort)
        {
            try
            {
                port.WriteLine(case_forPort);
            }
            catch
            {
                label2.Text = "Can't find port";
            }
        }

        static void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            for (int i = 0; i < (10000 * port.BytesToRead) / port.BaudRate; i++)
                ;       //Delay a bit for the serial to catch up
            Form1 ff = new Form1();
            ff.label2.Text = port.ReadExisting();
        }

       
    }
}
