using System;
using System.IO;
using System.Runtime.Serialization;
using System.Xml;
using System.Xml.Serialization;

namespace AMCserver
{

    public class Serilisationxml
    {
        string[] doorStatuts = { "Open", "Closed" };
        string[] lockStatuts = { "Open", "Closed" };

        public Stream Serilise(string _coorMACAddr)
            {

            Random ran = new Random();
            int n = ran.Next(0, 1);
            int m = ran.Next(0, 1);

            Status status = new Status()            
            {

                    coorMACAddr = _coorMACAddr,            
                    time = DateTime.Now.ToString(),
                    doorStatut = doorStatuts[n],
                    lockStatut = lockStatuts[m],
             };



                //On crée une instance de XmlSerializer dans lequel on lui spécifie le type
                //de l'objet à sérialiser. On utiliser l'opérateur typeof pour cela.
                XmlSerializer serializer = new XmlSerializer(typeof(Status));
            //Création d'un Stream Writer qui permet d'écrire dans un fichier. On lui spécifie le chemin
            //et si le flux devrait mettre le contenu à la suite de notre document (true) ou s'il devrait
            //l'écraser (false).
            MemoryStream streamXML = new MemoryStream();
                                   //On sérialise en spécifiant le flux d'écriture et l'objet à sérialiser.
           // serializer.Serialize(streamXML, status);
            serializer.Serialize(XmlWriter.Create(streamXML), status);
        
            streamXML.Seek(0, SeekOrigin.Begin);
 
            //IMPORTANT : On ferme le flux en tous temps !!!
            return streamXML;
            }

    }
}