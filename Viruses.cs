﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Viruses : MonoBehaviour
{
    [SerializeField]
    private float speed;


    private Stack<Node> path;
    public Point GridPosition { get; set; }
    public bool IsActive { get; set; }
    private Vector3 destination;



    private void Update()
    {


        Move();

    }


 



    public void Spawn()
    {
        transform.position = LevelManagement.Instance.BluePortal.transform.position;
        StartCoroutine(Scale(new Vector3(0.1f, 0.1f), new Vector3(1,1)));

        SetPath(LevelManagement.Instance.FinalPath);
    }


    public IEnumerator Scale(Vector3 from, Vector3 to)
    {

        IsActive = false;
        float progress = 0;
         while(progress <= 1)
        {
            transform.localScale = Vector3.Lerp(from, to, progress);

            progress += Time.deltaTime;

            yield return null;
        }

        transform.localScale = to;

        IsActive = true;
    }

    private void Move()
    {

        if(IsActive)
        {
            transform.position = Vector2.MoveTowards(transform.position, destination, speed * Time.deltaTime);

            if (transform.position == destination)
            {
                if (path != null && path.Count > 0)
                {
                    GridPosition = path.Peek().gridPosition;
                    destination = path.Pop().WorldPosition;
                }
            }
        }


       
    }


    private void SetPath(Stack<Node> newPath)
    {


        if(newPath != null)
        {


            this.path = newPath;
            GridPosition = path.Peek().gridPosition;
            destination = path.Pop().WorldPosition;
               
        }



    }
}
