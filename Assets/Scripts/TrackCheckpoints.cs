using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackCheckpoints : MonoBehaviour
{
    List<CheckpointSingle> checkpointSingleList;
    int nextCheckPointSingleIndex;
    private void Awake()
    {
        
        Transform checkpointsTransform = transform.Find("CheckPoints");
        checkpointSingleList = new List<CheckpointSingle>();
        foreach (Transform checkpointSingleTransform in checkpointsTransform)
        {
            CheckpointSingle checkpointSingle = checkpointSingleTransform.GetComponent<CheckpointSingle>();
            
            checkpointSingle.SetPathCheckpoints(this);

            checkpointSingleList.Add(checkpointSingle);

        }
        nextCheckPointSingleIndex = 0;
    }
    public void PlayerThroughCheckpoint(CheckpointSingle checkpointSingle)
    {
        if(checkpointSingleList.IndexOf(checkpointSingle) == nextCheckPointSingleIndex)
        {
            //correctChcekpoints
            Debug.Log("correct");
            nextCheckPointSingleIndex = (nextCheckPointSingleIndex + 1) % checkpointSingleList.Count;
        }
        else
        {

            //wrongCheckpoints
            Debug.Log("wrong");
        }
    }
}
