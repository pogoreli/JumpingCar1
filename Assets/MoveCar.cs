using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoveCar : MonoBehaviour
{
    //For the MoveCar part
    public GameObject Car;
    public float speed;
    private float CarZjump;
    public float JumpHeight=0;
    public TextMeshPro TextMesh;
    private float Jumping=0;
    public int score = 0;

    //Terrain behavior
    public GameObject PlaneMain;
    public GameObject PlanePrevious;
    public GameObject PlaneNext;
    private Vector3 PlaneMainV3;
    private Vector3 CarV3;
    private float CarZ;
    private float PlaneMainZ;
    private float PlaneNextZ; //PlaneMainZ+25
    private float PlaneMainX;
    private float PlaneMainY;

    //Obstacle generator
    public GameObject Truck;
    private Vector3 TruckLocation;
    private Vector3 CarLocation;
    private float TruckZ;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveGround();
        MoveForward();
        gravity();
        if (Input.GetKeyDown("space"))
        {
            Jump();
        }
        VarUpdate();
        randomPositionCaller();
    }

    void Jump()
    {
        if (Jumping <= 0.1f)
        {
            Jumping = JumpHeight;
        }

        
    }

    void gravity()
    {
        if (Jumping > 0)
        {
            Jumping -= 0.1f;
        }
    }
    void MoveForward()
    {
        CarZjump = Car.transform.position.z;
        Car.transform.position = new Vector3(0f, 0.5f+Jumping, CarZjump + speed);
        Car.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        TextMesh.text = "Score: "+score;
    }

    void MoveGround()
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

    void randomPositionCaller()
    {
        if (CarZ > TruckZ + 10f)
        {
            GenerateRandomPosition();
            AddScore();
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

    void AddScore()
    {
        score++;
    }

    void Collision()
    {
        score = 0;
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag=="Obstacles")
        {
            Collision();
        }
    }
}
