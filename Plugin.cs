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
    [ModdedGamemode]
    [BepInDependency("org.legoandmars.gorillatag.utilla", "1.5.0")]
    [BepInPlugin(PluginInfo.GUID, PluginInfo.Name, PluginInfo.Version)]
    public class Plugin : BaseUnityPlugin
    {
        bool inRoom;

        void OnGameInitialized(object sender, EventArgs e)
        {

        }

        void Update()
        {
            if (inRoom) 
            {
                Material[] array = (Material[])Material.FindObjectsOfType(typeof(Material));
                foreach (Material Material in array)
                {
                    Material.SetFloat("_Metallic", 1f);
                    Material.SetFloat("_Glossiness", 1f);
                }
            }
            else
            {
                Material[] array = (Material[])Material.FindObjectsOfType(typeof(Material));
                foreach (Material Material in array)
                {
                    Material.SetFloat("_Metallic", 0f);
                    Material.SetFloat("_Glossiness", 0.3f);
                }
            }
        }

        /* This attribute tells Utilla to call this method when a modded room is joined */
        [ModdedGamemodeJoin]
        public void OnJoin(string gamemode)
        {
            Material[] array = (Material[])Material.FindObjectsOfType(typeof(Material));
            foreach (Material Material in array)
            {
                Material.SetFloat("_Metallic", 1f);
                Material.SetFloat("_Glossiness", 1f);
            }
            inRoom = true;
        }

        /* This attribute tells Utilla to call this method when a modded room is left */
        [ModdedGamemodeLeave]
        public void OnLeave(string gamemode)
        {
            Material[] array = (Material[])Material.FindObjectsOfType(typeof(Material));
            foreach (Material Material in array)
            {
                Material.SetFloat("_Metallic", 0f);
                Material.SetFloat("_Glossiness", 0f);
            }
            inRoom = false;
        }
    }
}
