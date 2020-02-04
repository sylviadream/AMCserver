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
        public string messageID { get; set; }

        [XmlAttribute()]
        public string time { get; set; }

        [XmlAttribute()]
        public string netID { get; set; }

        [XmlAttribute()]
        public string masterControllerID { get; set; }

        [XmlAttribute()]
        public string webID { get; set; }

        public string clock { get; set; }
        public string lastTimeBoardReset { get; set; }
        public string firmwareVersion { get; set; }
        public string doorStatut { get; set; }
        public string lockStatut { get; set; }



    }

       
}


