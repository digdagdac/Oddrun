using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Stage : MonoBehaviour
{
    public GameObject[] stages;
    public float speed = 4f;
    private Vector3 initialPosition;
    public Transform player;
    public Vector2 boxSize;
    public GameObject gameover;
    [SerializeField] private Transform boxpos;
    [SerializeField] private GameObject RockPrefab;


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(SpawnRocks());
        initialPosition = stages[1].transform.position;
        StartCoroutine(MoveStages());
        
    }

    private IEnumerator MoveStages()
    {
        while (true)
        {
            
            foreach (GameObject stage in stages)
            {
                stage.transform.Translate(Vector3.left * speed * Time.deltaTime);
                

                if (stage.transform.position.x <= -140.0f)
                {
                    ResetStagePosition(stage);
                }
            }
            
            yield return null;
        }
    }

    public void BoxObj(GameObject rock)
    {
    Collider2D rockCollider = rock.AddComponent<BoxCollider2D>(); // Add a BoxCollider2D component to the rock
    rockCollider.isTrigger = true; // Set the collider to be a trigger

    // Perform actions based on collisions
    rockCollider.gameObject.tag = "Rock"; // Assign a tag to identify the rocks
    Debug.Log("damag");
    }


    private void ResetStagePosition(GameObject stage)
    {
        stage.transform.position = initialPosition;
    }

    

    private IEnumerator SpawnRocks()
    {
        while (true)
        {
            int RockCount = Random.Range(1, 5); // 1~4���� ���͸� �����ϰ� �����մϴ�.
            for (int i = 0; i < RockCount; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(15, 30), -6.89f, 0);
                GameObject rockInstance = Instantiate(RockPrefab, spawnPosition, Quaternion.identity);
                BoxObj(rockInstance);
                StartCoroutine(MoveRock(rockInstance));
                
            yield return new WaitForSeconds(5f); // 
        }
        }
    }
    IEnumerator MoveRock(GameObject rock)
    {
    while (true)
    {
        
        rock.transform.Translate(Vector3.left * speed * Time.deltaTime);
        yield return null;
    }   
    }


}