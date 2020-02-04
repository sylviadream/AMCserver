using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AMCserver
{
    public class CommunicaXML
    {

             
    static byte[] FileTOByte(String path) 
    {
   
    FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
    byte[] infbytes = new byte[(int)fs.Length]; 
            fs.Read(infbytes, 0, infbytes.Length);
            fs.Close(); 
            return infbytes; } 

     }
}
