using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;
using System;

public class ObjectSpawner : MonoBehaviour
{
    public string cubeCount;
    public float pauseTime;
    public GameObject input;
    public GameObject spawnObject;

    // Start is called before the first frame update
    void Start()
    {
        waiter();
    }

    public async void waiter()
    {
        cubeCount = input.GetComponent<Text>().text;
        for (int i = 0; i < int.Parse(cubeCount); i++)
        {
            Instantiate(spawnObject, this.transform.position, this.transform.rotation);
            await Task.Delay(TimeSpan.FromSeconds(pauseTime));
        }
    }


    // Update is called once per frame
    void Update()
    {

    }

}