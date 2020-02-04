using System;
using System.IO;
using System.Xml.Serialization;

namespace AMCserver
{

    public class Serilisationxml
    {


            public void Serilise(string _coorMACAddr , string _doorStatut, string _lockStatut)
            {
             
                string _messageID = "Yvan";
                string _netID = "55";
                string _masterControllerID = "Yvan";
                string _webID = "55";
                string _clock = "55";
                string _lastTimeBoardReset = "55";
                string _firmwareVersion = "55";


            Status status = new Status()
            {
                coorMACAddr = _coorMACAddr,
                messageID = _messageID,
                masterControllerID = _masterControllerID,
                    netID = _netID,
                    webID = _webID,
                    clock = _clock,
                    lastTimeBoardReset = _lastTimeBoardReset,
                    firmwareVersion = _firmwareVersion,
                    time = DateTime.Now.ToString(),
                    doorStatut = _doorStatut,
                    lockStatut = _lockStatut,
                };



                //On crée une instance de XmlSerializer dans lequel on lui spécifie le type
                //de l'objet à sérialiser. On utiliser l'opérateur typeof pour cela.
                XmlSerializer serializer = new XmlSerializer(typeof(Status));

                //Création d'un Stream Writer qui permet d'écrire dans un fichier. On lui spécifie le chemin
                //et si le flux devrait mettre le contenu à la suite de notre document (true) ou s'il devrait
                //l'écraser (false).
                StreamWriter ecrivain = new StreamWriter("TestServer.xml", false); 

                //On sérialise en spécifiant le flux d'écriture et l'objet à sérialiser.
                serializer.Serialize(ecrivain, status);

                //IMPORTANT : On ferme le flux en tous temps !!!
                ecrivain.Close();
            }

    }
}