using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainBehavior : MonoBehaviour
{
    public GameObject PlaneMain;
    public GameObject PlanePrevious;
    public GameObject PlaneNext;
    public GameObject Car;
    //public GameObject Planes;

    private Vector3 PlaneMainV3;
    private Vector3 CarV3;
    
    private float CarZ;
    private float PlaneMainZ;
    private float PlaneNextZ; //PlaneMainZ+25
    
    private float PlaneMainX;
    private float PlaneMainY;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        PlaneMainV3 = PlaneMain.transform.position;
        CarV3 = Car.transform.position;

        CarZ = CarV3.z;
        PlaneMainZ = PlaneMainV3.z;
        PlaneNextZ = PlaneMainZ + 25f;

        PlaneMainX = PlaneMainV3.x;
        PlaneMainY = PlaneMainV3.y;

        if (CarZ >= PlaneNextZ)
        {
            PlaneMain.transform.position = new Vector3(PlaneMainX, PlaneMainY, PlaneNextZ);
            PlaneNext.transform.position = new Vector3(PlaneMainX, PlaneMainY, PlaneNextZ + 87f);
            PlanePrevious.transform.position = new Vector3(PlaneMainX, PlaneMainY, PlaneNextZ - 35);
        }
    }
}
