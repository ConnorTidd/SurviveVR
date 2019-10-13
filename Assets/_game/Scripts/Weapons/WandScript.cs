using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WandScript : MonoBehaviour
{

    public float _charge = 10;

    public float chargeMax;
    public float chargeRate;
    private double time = 0.1;
    public GameObject ElectricSpellCharged;
    public Transform spawn;
    public GameObject Lightning;

    public Rigidbody Particle;

    private float sequence = 1;
    public bool lightningCanShoot = false;
    public float lightningShots = 10;

    void Start()
    {

    }

    void Update()
    {
        if(lightningShots <= 0)
        {
            lightningCanShoot = false;
        }

        if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
       {
           
            if (lightningCanShoot)
            {
                StartCoroutine(Example());
                lightningShots = lightningShots - 1;
                
            }
            ///GameObject lightning = Instantiate(Lightning);
           //LightningBoltScript lightningScript = lightning.GetComponent<LightningBoltScript>();
           // lightningScript.setBothPoints();


            //Destroy(spellParticle, 2f);
            //OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger)

        }
    }

    IEnumerator Example()
    {
        
        //for (int i = 0; i < 5; i++)
      //  {
            yield return new WaitForSeconds((float)time);
            //Rigidbody Particle = spellParticle.GetComponent<Rigidbody>();
            Rigidbody spell = Instantiate(Particle, spawn.position, Quaternion.LookRotation(spawn.forward)) as Rigidbody;
            spell.AddForce(spawn.forward * _charge, ForceMode.Impulse);
           // Debug.Log("pressed");

       // }

    }

    public void spellDrawTrigger(float currentOrb, float totalOrbs)
    {

        if(currentOrb == sequence)
        {
            
            Debug.Log(sequence);
            sequence++;
            Debug.Log(sequence);
            if (currentOrb == totalOrbs)

            {
                StartCoroutine(Example());
                activateSpell(totalOrbs);
                sequence = 1;

            }

        }
        else
        {
            sequence = 1;
        }
    }

    public void activateSpell(float whichSpell)
    {
        // if(whichSpell == 4)
        //{
        Debug.Log("activated");
        lightningCanShoot = true;
        lightningShots = 10;
       // }
    }
}
