using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour
{
    public GameObject[] stages;
    public float speed = 4f;
    private Vector3 initialPosition;

    private void Start()
    {
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

    private void ResetStagePosition(GameObject stage)
    {
        stage.transform.position = initialPosition;
    }
}