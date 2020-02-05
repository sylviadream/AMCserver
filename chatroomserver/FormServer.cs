using System;
using System.Collections.Generic;

using System.Windows.Forms;

using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;
using System.Threading.Tasks;

namespace AMCserver
{
    public partial class FormChatServer : Form         
    {
         
  
     
        private Dictionary<string ,Socket> dict=new Dictionary<string, Socket>();
        static Semaphore sem = new Semaphore(1, 1);

        public FormChatServer()
        {
            InitializeComponent();           
        }
        private void btnListen_Click(object sender, EventArgs e)
        { 
         

            string[] str_ports = { "8090", "9001", "9002", "9003", "9004", "9005", "9006" };
            string str_adress = "127.0.0.1";
            foreach (string str_port in str_ports)
            {
                TaskFactory taskfactory = new TaskFactory();
                taskfactory.StartNew(n => {
                    OnesocateStart(str_adress, str_port);
                }, TaskCreationOptions.None);

            }
                       
        }
        

        void OnesocateStart(string str_adress, string str_port)
        {

   
           IPAddress zxz_ip = IPAddress.Parse(str_adress);

            IPEndPoint ippoint = new IPEndPoint(zxz_ip, int.Parse(str_port));
            Socket socketWatch = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socketWatch.Bind(ippoint);

            socketWatch.Listen(1);
            WatchConnection(socketWatch);

            this.ShowMsg("------start the server------" + str_port);
        }

        //private Socket sockConnection = null;

        void WatchConnection(Socket socketWatch)
        {
            while (true)
            {

                sem.WaitOne();
                Socket sockConnection = socketWatch.Accept();           
                dict.Add(sockConnection.RemoteEndPoint.ToString(),sockConnection);

                sem.Release();
                BindListBox();
            
                Thread t = new Thread(RecMsg);
         
                t.IsBackground = true;
        
                t.Start(sockConnection);
                this.ShowMsg("-----" + sockConnection.RemoteEndPoint.ToString() + ":client in-----");
            }           
     
        }

      
        /// <param name="o"></param>
        void RecMsg(object o)
        {
           ;
            while (true)
            {
                try
                {                    
                    byte[] arrMsgRec = new byte[1024 * 1024 * 2];
              
                    Socket socketClient = o as Socket;
                    int length = socketClient.Receive(arrMsgRec);
                   
                    string strMsgRec = System.Text.Encoding.UTF8.GetString(arrMsgRec, 0, length);             

                    //texttoEnvoye = strMsgRec;            
                    Serilisationxml serilise = new Serilisationxml();



                    Stream streamXML = serilise.Serilise(socketClient.LocalEndPoint.ToString());

                    for (int a = 10; a < 20; a = a + 1)
                    {
                        senttoClient(FileTOByte(streamXML));
                        Thread.Sleep(1000 * 60);

                    }
                    

                }
                catch (Exception e)
                {
                    Socket socketClient = o as Socket;
                    ShowMsg("-----"+e.ToString() );
               
                    dict.Remove(socketClient.RemoteEndPoint.ToString());
           
                    BindListBox();
                
                    socketClient.Close();
                 
                    Thread.CurrentThread.Abort();
                }
                        

            }
           
        }

        private delegate void changeText(string msg);

        /// <param name="msg"></param>
        void ShowMsg(string msg)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new changeText(ShowMsg), msg);
            }
            else
            {
                txtMsg.AppendText(msg + "\r\n"); 
            }            
        }

        private delegate void changeListbox();
   
        void BindListBox()
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new changeListbox(BindListBox));
            }
            else
            {
              //  OnLine.Items.Clear();
                foreach (var item in dict)
                {
                //    OnLine.Items.Add(item.Key);
                }
            }
        }


        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void senttoClient(byte[] arrMsg)
        {   
           
            //sockConnection.Send(arrMsg);
      
            //string selectkey = null;
            Socket socketSend = null;
            foreach (var item in dict)
            {
                socketSend = dict[item.Key];
                socketSend.Send(arrMsg);
            }   
        }

        static byte[] FileTOByte(Stream streamXML)
        {

            //FileStream fs = new FileStream(streamXML, FileMode.Open, FileAccess.Read);
            byte[] infbytes = new byte[(int)streamXML.Length];
            streamXML.Read(infbytes, 0, infbytes.Length);
            string x = streamXML.ToString();
            streamXML.Close(); 
            return infbytes;
        }


    }
}

