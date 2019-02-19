using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Counter.Engine.Rules
{
   public  class OutputWriter
    {

        public static void WriteToFile(int input, string filenameWithPath)
        {

           FileStream fs=new FileStream(filenameWithPath,FileMode.Create);
            StreamWriter stream = new StreamWriter(fs);
            stream.Write(input);
            stream.Close();
        }

    }
}
