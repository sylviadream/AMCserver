using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;

namespace AMCserver
{
    public partial class FormChatServer : Form         
    {
         private Thread threadWatch = null;
  
        private Dictionary<string ,Socket> dict=new Dictionary<string, Socket>(); 
        private Socket socketWatch = null;

        public FormChatServer()
        {
            InitializeComponent();
            TextBox.CheckForIllegalCrossThreadCalls = false;
        }
        private void btnListen_Click(object sender, EventArgs e)
        { 
            socketWatch = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        
            IPAddress zxz_ip = IPAddress.Parse("127.0.0.1");
     
            IPEndPoint ippoint = new IPEndPoint(zxz_ip, int.Parse(this.txtPort.Text.Trim()));
       
            socketWatch.Bind(ippoint);
           
            socketWatch.Listen(1);
      
            //Socket sockConnection=socketWatch.Accept();       

            threadWatch = new Thread(WatchConnection);
            threadWatch.IsBackground = true;
            threadWatch.Start();
            ShowMsg("------start the server------");
        }

        //private Socket sockConnection = null;
   
        void WatchConnection()
        {
            while (true)
            {
         
                Socket sockConnection = socketWatch.Accept();
           
                dict.Add(sockConnection.RemoteEndPoint.ToString(),sockConnection);
               
                BindListBox();
            
                Thread t = new Thread(RecMsg);
         
                t.IsBackground = true;
        
                t.Start(sockConnection);
                ShowMsg("-----" + sockConnection.RemoteEndPoint.ToString() + ":client in-----");
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

                    ShowMsg(strMsgRec);
                    //texttoEnvoye = strMsgRec;            
                    Serilisationxml serilise = new Serilisationxml();

                    serilise.Serilise(this.MacAdresInput.Text, this.DoorStatuInput.Text, this.LockStatInput.Text);

                    for (int a = 10; a < 20; a = a + 1)
                    {
                        senttoClient(FileTOByte("TestServer.xml"));
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

        static byte[] FileTOByte(String path)
        {

            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            byte[] infbytes = new byte[(int)fs.Length]; 
            fs.Read(infbytes, 0, infbytes.Length); 
            fs.Close(); 
            return infbytes;
        }


    }
}

