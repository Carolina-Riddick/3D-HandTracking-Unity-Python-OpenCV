using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandTracking : MonoBehaviour
{

    public UDPReceive UdpReceiveData;
    public GameObject[] handPoints;


    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        string data = UdpReceiveData.data;
        data = data.Remove(0, 1 );
        data = data.Remove(data.Length - 1, 1);
        string[] points = data.Split(',');

        // 0        1*3      2*3   
        // x1 y1 z1 x2 y2 z2 x3 y3 z3

        for (int i = 0; i < handPoints.Length ; i++) {

            float x = 6 - float.Parse(points[i*3]) / 120;
            float y = float.Parse(points[(i * 3) + 1]) / 120;
            float z = float.Parse(points[(i * 3 ) + 2]) / 120;

            //handPoints[i].transform.position.Set(x,y,z);

            handPoints[i].transform.localPosition = new Vector3(x, y, z);
        }
    }
}
