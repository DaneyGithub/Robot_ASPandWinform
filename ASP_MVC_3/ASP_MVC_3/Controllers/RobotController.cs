using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP_MVC_3.Controllers
{
    public class RobotController : Controller
    {
        static SerialPort port;
        // GET: Robot
        public ActionResult Index()
        {
            Stop();
            return View();
        }
          
        

        // This code is the orginal working one 
        // It has a view and replaced by Forward to test without view
        /*
        [HttpPost]
        public ActionResult Work()
        {
            OpenPort();
            AddCaseForPort("1"); //1 is Red and forward
            port.Close();
            return View("Index");

        }
        */

        [HttpPost]
        public ActionResult Forward()
        {
            OpenPort();
            AddCaseForPort("1"); //1 is Red and forward
            port.Close();
            return View("Index");

        }

        [HttpPost]
        public ActionResult Back()
        {
            OpenPort();
            AddCaseForPort("2"); //2 to Back
            port.Close();
            return View("Index");
        }

        [HttpPost]
        public ActionResult Stop()
        {
            OpenPort();
            AddCaseForPort("3"); //3 to stop
            port.Close();
            return View("Index");
        }

        [HttpPost]
        public ActionResult Left()
        {
            OpenPort();
            AddCaseForPort("4"); //3 to stop
            port.Close();
            return View("Index");
        }

        [HttpPost]
        public ActionResult Right()
        {
            OpenPort();
            AddCaseForPort("5"); //3 to stop
            port.Close();
            return View("Index");
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
              //  label1.Text = "Can't Open port";

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
              //  label2.Text = "Can't find port";
            }
        }

        static void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            for (int i = 0; i < (10000 * port.BytesToRead) / port.BaudRate; i++)
                ;       //Delay a bit for the serial to catch up
           
        }
        
    }
}