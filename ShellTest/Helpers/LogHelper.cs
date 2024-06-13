using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShellTest.Helpers
{
    public class LogHelper
    {

        //Global Declaration

        private static string _logFileName = string.Format("{0:yyyymmddhhmmss}", DateTime.Now);

        private static StreamWriter _streamw = null;



        //create a file which can store the  log info
        public static void CreateLogFile()
        {

            string dir = @"D:\CWorkspace\ShellWorkspace\LogFiles\";

            if (Directory.Exists(dir))

            {
                _streamw = File.AppendText(dir + _logFileName + ".log");




            }
            else
            {

                Directory.CreateDirectory(dir);

                _streamw = File.AppendText(dir + _logFileName + ".log");



            }



        }




        //Create a method which can write the text in the log file

        public static void Write (string logMessage)

            {
            _streamw.Write( " {0}  {1}  ", DateTime.Now.ToLongTimeString(),DateTime.Now.ToLongDateString()  );
            _streamw.WriteLine("      {0}", logMessage);


            _streamw.Flush();



            }


    }
}
