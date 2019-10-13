/*
    Copyright (C) 2016 FusionEd

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <http://www.gnu.org/licenses/>.
 */


using UnityEngine;
using System.Collections;

public class Arrow : MonoBehaviour {

	public bool isAttached = false;
    public GameObject scoreDisplay;

    private bool isFired = false;

    public int damage;
    //public GameObject impactEffect;
   // public Transform arrowspawn;

    void OnTriggerStay() {
		
	}

	void OnTriggerEnter(Collider col) {
		

       
        if (col.GetComponent<EnemyStats>())
        {
            if (isFired) { 
                this.GetComponent<Collider>().isTrigger = false;
                
            }   
            EnemyStats enemyStats = col.GetComponent<EnemyStats>();
            enemyStats.Hit(damage);
            PlayerStats playerStats = col.GetComponent<PlayerStats>();
            playerStats.Hit(damage);
            
            


            //PARTICLE EFFECT
            // GameObject impactGO = Instantiate(impactEffect, arrowspawn.position, Quaternion.LookRotation(arrowspawn.forward));
            // Destroy(impactGO, 0.1f);
        }
        else if (col.GetComponent<GameStarter>())
        {
            if (isFired)
            {
                this.GetComponent<Collider>().isTrigger = false;
            }
            GameStarter starter = col.GetComponent<GameStarter>();
            starter.StartLevel();
        }
    }

	void Update() {


        
        if (isFired)
        {
            Destroy(gameObject, 2f);
        }

    }

	public void Fired() {
		isFired =  true; 
	}

	private void AttachArrow() {
        if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
        {
           // Debug.Log("attacharrow");
        }

        if (!isAttached && OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger)) {
			NewArrowManager.Instance.AttachBowToArrow ();
			isAttached = true;
            
        }
	}

    


}
