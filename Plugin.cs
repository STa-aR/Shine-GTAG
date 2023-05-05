using BepInEx;
using System;
using Unity.Mathematics;
using UnityEngine;
using Utilla;

namespace Shine
{
    /// <summary>
    /// This is your mod's main class.
    /// </summary>

    /* This attribute tells Utilla to look for [ModdedGameJoin] and [ModdedGameLeave] */
    [BepInPlugin(PluginInfo.GUID, PluginInfo.Name, PluginInfo.Version)]
    public class Plugin : BaseUnityPlugin
    {
        void OnGameInitialized(object sender, EventArgs e)
        {

        }

        void Update()
        {
            Material[] array = (Material[])Material.FindObjectsOfType(typeof(Material));
            foreach (Material Material in array)
            { 
                Material.SetFloat("_Metallic", 1f);
                Material.SetFloat("_Glossiness", 1f);
            }
        }
    }
}
