using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;          // Serial stuff in here.

namespace WindowsFormsSerialCaller
{
    class Serial
    {
        static SerialPort port;

        // static void Main(string[] args)
        public void Some()
        {
            string portNumber = "COM4";

            port = new SerialPort(portNumber, 9600);

            try //If the port is open
            {
                port.DataReceived += new SerialDataReceivedEventHandler(port_DataReceived);
                port.Open();
                Console.WriteLine("Serial Started.");
                Console.WriteLine("Ctrl+C to exit program");
                Console.WriteLine("Send:");

                for (; ; )
                {
                    // Console.WriteLine(" ");
                    Console.WriteLine(">");
                    port.WriteLine(Console.ReadLine());
                }
            }
            catch
            {
                Console.WriteLine("Can't connect port at {0}", portNumber);
                Console.ReadLine();
            }




        }

        static void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            for (int i = 0; i < (10000 * port.BytesToRead) / port.BaudRate; i++)
                ;       //Delay a bit for the serial to catch up
            Console.Write(port.ReadExisting());
            Console.WriteLine(">");
        }


    }
}