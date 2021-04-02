using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerManager : MonoBehaviour
{
    public float health;
    bool dead = false;
    // Start is called before the first frame update
    //childın transformuna ulasmaya calısıyorum
    Transform muzzle;
    public Transform bullet, floatingText;
    public float bulletSpeed;

    public Slider slider;
    
    void Start()
    {
        muzzle = transform.GetChild(1);
        slider.maxValue = health;
        slider.value = health;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            ShootBullet();
        }
    }
    public void GetDamage(float damage)
    {
        Instantiate(floatingText, transform.position, Quaternion.identity).GetComponent<TextMesh>().text = damage.ToString();
        if((health-damage) >=0)
        {
            health -= damage;
        }
        else
        {
            health = 0;
        }
        slider.value = health;
        AmIDead();
    }
    void AmIDead()
    {
        if(health<=0)
        {
            dead = true;
        }
    }
    void ShootBullet()
    {
        Transform tempBullet; // her mermiye gecici süre ulasmak için
        tempBullet = Instantiate(bullet, muzzle.position, Quaternion.identity);
        tempBullet.GetComponent<Rigidbody2D>().AddForce(muzzle.forward * bulletSpeed);//forward burada z ekseni oldugu için sorun yasadık mermi gitmedi bu yüzden oyunu 3d yapıp z eksenini düzeltiyoruz

    }
}
