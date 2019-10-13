using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour {

    public int health;
    public bool isHit;
    private string newColor;
    private Color blockColor = new Color(1f,1f,1f,1f);

    void Update()
    {
        if(health <=0)
        {
            Debug.Log("dead");
            Destroy(gameObject);
                

        }
    }

    public void Hit (int damage)
    {
        float decreaseColor = health / 10;
        health -= damage;
        blockColor.r = 1;
        blockColor.g = decreaseColor;
        blockColor.b = decreaseColor;
        blockColor.a = 1;


        this.GetComponent<Renderer>().material.SetColor("_Color", new Color(1f, health/10f, health/10f, 1f));
        isHit = true;
        
        Debug.Log(health);
    }
}
