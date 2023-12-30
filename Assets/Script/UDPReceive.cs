using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System;

public class UDPReceive : MonoBehaviour
{
    Thread receiveThread;
    UdpClient client;
    [SerializeField] int port = 5052;
    [SerializeField] bool startReceiving = true;
    [SerializeField] bool printToConsole = true;
    public string data;

    public void Start()
    {
        receiveThread = new Thread(
                new ThreadStart(ReceiveData));
        receiveThread.IsBackground = true;
        receiveThread.Start();
    }

    // Receiving the Thread 
    private void ReceiveData()
    {
        client = new UdpClient(port);
        while (startReceiving)
        {
            try
            {
                IPEndPoint anyIP = new IPEndPoint(IPAddress.Any, 0);
                byte[] dataByte = client.Receive(ref anyIP);
                data = Encoding.UTF8.GetString(dataByte);

                if (printToConsole)
                {
                    print(data);
                }
            } catch (Exception error)
            {
                print(error.ToString());
            }
        }
    }
}