using flanne;
using flanne.AISpecials;
using HarmonyLib;
using UnityEngine;

namespace DiscoShoggoth
{
    class AILaserSpecialPatch
    {
        [HarmonyPatch(typeof(AILasersSpecial), "LaserCR")]
        [HarmonyPrefix]
        static void LaserCRPrefix(GameObject windupObj, GameObject laserObj)
        {
            for (int i = 0; i < laserObj.transform.childCount; i++)
            {
                Transform laser = laserObj.transform.GetChild(i);
                Transform windUp = windupObj.transform.GetChild(i);

                Color laserColor = Random.ColorHSV(0f, 1f, 1f, 1f, 1f, 1f);
                laser.gameObject.GetComponent<SpriteRenderer>().color = laserColor;
                windUp.gameObject.GetComponent<SpriteRenderer>().color = laserColor;
            }
        }
    }
}