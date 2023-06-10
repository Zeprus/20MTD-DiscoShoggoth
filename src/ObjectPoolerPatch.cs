using flanne;
using HarmonyLib;
using UnityEngine;
using static DiscoShoggoth.Plugin;

namespace DiscoShoggoth
{
    internal class ObjectPoolerPatch
    {
        [HarmonyPatch(typeof(ObjectPooler), "Awake")]
        [HarmonyPrefix]
        static void AwakePrefix(ref ObjectPooler __instance)
        {
            foreach (ObjectPoolItem objectPoolItem in __instance.itemsToPool)
            {
                if(objectPoolItem.objectToPool.name == "Shoggoth") {
                    TryReplaceShoggothTexture(objectPoolItem.objectToPool.gameObject);
                }
            }
        }

        [HarmonyPatch(typeof(ObjectPooler), "AddObject")]
        [HarmonyPrefix]
        static bool AddObjectPrefix(string tag, GameObject GO, int amt, bool exp)
        {
            if(GO.name == "Shoggoth") {
                TryReplaceShoggothTexture(GO);
            }

            return true;
        }

        private static void TryReplaceShoggothTexture(GameObject go)
        {
            Sprite sprite = go.GetComponent<SpriteRenderer>().sprite;
            Texture2D texture2D = new Texture2D(sprite.texture.width, sprite.texture.height, sprite.texture.format, 1, false);
            if(sprite.texture.LoadImage(shoggothImageBytes)) {
                texture2D.Apply();
            } else {
                Log.LogError("Failed to load Shoggoth disco texture.");
            }

        }
    }
}