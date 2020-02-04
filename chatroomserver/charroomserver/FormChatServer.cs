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


namespace chatroomserver
{
    public partial class FormChatServer : Form

         
    {
        public FormChatServer()
        {
            InitializeComponent();
            TextBox.CheckForIllegalCrossThreadCalls = false;
        }

        private Thread threadWatch = null;
  
        private Dictionary<string ,Socket> dict=new Dictionary<string, Socket>(); 
        private Socket socketWatch = null;
        private void btnListen_Click(object sender, EventArgs e)
        {
            
            if (socketWatch==null)
            {
                socketWatch = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            }
            else
            {
                return;
            }
        
            IPAddress zxz_ip = IPAddress.Parse(this.txtIP.Text.Trim());
     
            IPEndPoint ippoint = new IPEndPoint(zxz_ip, int.Parse(this.txtPort.Text.Trim()));
       
            socketWatch.Bind(ippoint);
           
            socketWatch.Listen(10);

      
            //Socket sockConnection=socketWatch.Accept();

       

            threadWatch = new Thread(WatchConnection);
            threadWatch.IsBackground = true;
            threadWatch.Start();
            ShowMsg("------open the server------");
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
                ShowMsg("-----" + sockConnection.RemoteEndPoint.ToString() + ":客户端连接进入-----");
            }
            
     
        }

      
        /// <param name="o"></param>
        void RecMsg(object o)


        {

            string texttoEnvoye="";
            while (true)
            {
                try
                {
                    
                    byte[] arrMsgRec = new byte[1024 * 1024 * 2];
              
                    Socket socketClient = o as Socket;
                    int length = socketClient.Receive(arrMsgRec);
                   
                    string strMsgRec = System.Text.Encoding.UTF8.GetString(arrMsgRec, 0, length);
              

                    ShowMsg(strMsgRec);
                    texttoEnvoye = strMsgRec;

                }
                catch (Exception e)
                {
                    Socket socketClient = o as Socket;
                    ShowMsg("-----"+socketClient.RemoteEndPoint.ToString() + "已经离开！-----");
               
                    dict.Remove(socketClient.RemoteEndPoint.ToString());
           
                    BindListBox();
                
                    socketClient.Close();
                 
                    Thread.CurrentThread.Abort();
                }
                senttoClient(texttoEnvoye);            

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
                liboxOnLine.Items.Clear();
                foreach (var item in dict)
                {
                    liboxOnLine.Items.Add(item.Key);
                }
            }
        }


        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void senttoClient(string str)
        {
            
    
            byte[] arrMsg=System.Text.Encoding.UTF8.GetBytes(str);
            //sockConnection.Send(arrMsg);
      
            //string selectkey = null;
            Socket socketSend = null;
            foreach (var item in dict)

            {
                socketSend = dict[item.Key];
                socketSend.Send(arrMsg);    
               

            }
          
        
            
   
        }

 

    }
}
