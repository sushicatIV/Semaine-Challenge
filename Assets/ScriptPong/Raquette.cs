using UnityEngine;
 
public class Raquette : MonoBehaviour
{
    public float vitesse = 6f;
    public KeyCode toucheHaut;
    public KeyCode toucheBas;
 
    void Update()
    {
        if (Input.GetKey(toucheHaut) && transform.position.y < 4f)
            transform.Translate(0, vitesse * Time.deltaTime, 0);
 
        if (Input.GetKey(toucheBas) && transform.position.y > -4f)
            transform.Translate(0, -vitesse * Time.deltaTime, 0);
    }
}