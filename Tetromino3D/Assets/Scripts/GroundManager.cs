using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundManager : MonoBehaviour
{
    public GameObject groundPrefab;
    public GameObject firstGround;

    private bool finishMoveGround;
    private bool finishedRandomGround;
    private List<GameObject> listGroundForward = new List<GameObject>();
    private List<GameObject> listGroundBack = new List<GameObject>();
    private Vector3 firstForwardPos;
    private Vector3 firsBackPos;
    private int numberOfGrounds = 5;


    void Start()
    {
        firstForwardPos = firstGround.transform.position + Vector3.forward * firstGround.transform.localScale.z +
            new Vector3(0,-10,0);
        firsBackPos = firstGround.transform.position + Vector3.back * firstGround.transform.localScale.z * 2 +
            new Vector3(0, -10, 0);

        StartCoroutine(RandomGroundForward(firstForwardPos, numberOfGrounds,listGroundForward));
        StartCoroutine(RandomGroundBack(firsBackPos, numberOfGrounds, listGroundForward));

    }

    void Update()
    {

    }

    IEnumerator MoveGround(GameObject ground,Vector3 startPos, Vector3 endPos, float timeToMove)
    {
        float t = 0;
        while (t < timeToMove)
        {
            float fraction = t / timeToMove;
            ground.transform.position = Vector3.Lerp(startPos, endPos, fraction);
            t += Time.deltaTime;
            yield return null;
        }
        ground.transform.position = endPos;
        finishMoveGround = true;
    }

    IEnumerator RandomGroundForward(Vector3 position, int number,List<GameObject> newList)
    {
        finishedRandomGround = false;
        for (int i = 0; i < number; i++)
        {
            GameObject currentGround = Instantiate(groundPrefab, position, Quaternion.identity);
            newList.Add(currentGround);
            currentGround.transform.SetParent(firstGround.transform.parent);
            position = currentGround.transform.position + Vector3.forward * currentGround.transform.localScale.z;
            yield return new WaitForSeconds(0.1f);
        }
        finishedRandomGround = true;
    }

    IEnumerator RandomGroundBack(Vector3 position, int number, List<GameObject> newList)
    {
        finishedRandomGround = false;
        for (int i = 0; i < number; i++)
        {
            GameObject currentGround = Instantiate(groundPrefab, position, Quaternion.identity);
            newList.Add(currentGround);
            currentGround.transform.SetParent(firstGround.transform.parent);
            position = currentGround.transform.position + Vector3.back * currentGround.transform.localScale.z;
            yield return new WaitForSeconds(0.1f);
        }
        finishedRandomGround = true;
    }
}
