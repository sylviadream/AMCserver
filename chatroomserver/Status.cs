using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace AMCserver
{

    [Serializable ]
    public class Status
    {
        [XmlAttribute()]
        public string coorMACAddr { get; set; }     
      

        [XmlAttribute()]
        public string time { get; set; }

   
        public string doorStatut { get; set; }
        public string lockStatut { get; set; }



    }

       
}


