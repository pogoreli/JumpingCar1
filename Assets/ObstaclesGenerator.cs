using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesGenerator : MonoBehaviour
{
    public GameObject Truck;
    public GameObject Car;

    private Vector3 TruckLocation;
    private Vector3 CarLocation;

    private float TruckZ;
    private float CarZ;

    // Start is called before the first frame update
    void Start()
    {
        //Car = GameObject.Find("SportsCar");
        //MoveCar moveCar = Car.GetComponent<MoveCar>();
    }

    // Update is called once per frame
    void Update()
    {
        VarUpdate();
        randomPositionCaller();
    }

    void randomPositionCaller()
    {
        if (CarZ > TruckZ + 10f)
        {
            GenerateRandomPosition();
        }
    }
    void VarUpdate()
    {
        TruckLocation = Truck.transform.position;
        CarLocation = Car.transform.position;

        TruckZ = TruckLocation.z;
        CarZ = CarLocation.z;
    }
    void GenerateRandomPosition()
    {
        Truck.transform.position = new Vector3(0f, 0.5f, Random.Range(CarZ + 30f, CarZ + 250f));
        Truck.GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
    }

}
