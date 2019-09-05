﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Portal : InteractionObject
{
    private int otherObjectColor;

    private bool isCollision = false;

    private void OnTriggerEnter(Collider other)
    {
        otherObjectColor = GetColorIndex();
        if (otherObjectColor.Equals(colorNumber) && !isCollision)
        {
            Debug.Log("Game Clear");
            Interaction();
            isCollision = true;
            StartCoroutine(CollisionWait());
        }
    }

    protected override void Interaction(){
        Effect();
        StageManager.instance.GameClear();

    }

    private IEnumerator CollisionWait()
    {
        yield return new WaitForSeconds(0.1f);
        isCollision = false;
    }

}
