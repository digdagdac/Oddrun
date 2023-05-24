using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageEx : MonoBehaviour
{
    public GameObject stage;
    public GameObject stage2;   // 2nd stage
    public float speed = 4f;
    private Vector3 initialPosition;
    private void Start()
    {
       
        initialPosition = stage2.transform.position;
        StartCoroutine(MoveStage());
    }

    private IEnumerator MoveStage()
    {
        while (true)
        {
            stage.transform.Translate(Vector3.left * speed * Time.deltaTime);
            stage2.transform.Translate(Vector3.left * speed * Time.deltaTime);

            if (stage.transform.position.x <= -140.0f)
            {
                ResetStagePosition();
            }
            if(stage2.transform.position.x <= -140.0f)
            {
                ResetStagePosition2();
            }
            yield return null;
        }
    }

    private void ResetStagePosition()
    {
        stage.transform.position = initialPosition;

    }
    private void ResetStagePosition2()
    {
        stage2.transform.position = initialPosition;

    }

}
