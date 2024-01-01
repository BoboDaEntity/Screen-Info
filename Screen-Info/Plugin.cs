using System;
using System.Drawing;
using BepInEx;
using Photon.Pun;
using UnityEngine;
using UnityEngine.XR;

namespace ScreenInfo
{
    [BepInPlugin("com.Bobo.ScreenInfo", "ScreenInfo", "1.0.3")]
    public class Plugin : BaseUnityPlugin
    {
        private void OnGUI()
        {
            this.guiStyle.fontSize = 20;
            this.guiStyle.normal.textColor = UnityEngine.Color.red;
            this.guiStyle.fontStyle = FontStyle.Bold;
            GUI.Label(new Rect(15f, 25f, 200f, 40f), " " + PhotonNetwork.LocalPlayer.NickName, this.guiStyle);
            if (PhotonNetwork.InRoom)
            {
                GUI.Label(new Rect(15f, 50f, 200f, 20f), "<color=white> Current Code:  </color>" + PhotonNetwork.CurrentRoom.Name, this.guiStyle);
                GUI.Label(new Rect(15f, 75f, 200f, 40f), "<color=white> There are </color>" + PhotonNetwork.CurrentRoom.PlayerCount.ToString() + "<color=white> people in this room </color>", this.guiStyle);
                GUI.Label(new Rect(15f, 100f, 200f, 40f), "<color=white> GameMode: </color>" + GorillaGameManager.instance.GameMode(), this.guiStyle);
                GUI.Label(new Rect(15f, 125f, 200f, 40f), FrameRate.ToString() + "<color=white> FPS </color>");
                GUI.Label(new Rect(15f, 150f, 200f, 40f), Ping.ToString() + "<color=white> PING </color>");
            }
            if (!PhotonNetwork.InRoom)
            {
                GUI.Label(new Rect(15f, 50f, 200f, 20f), "<color=white> Not In a Code </color>", this.guiStyle);
                GUI.Label(new Rect(15f, 75f, 200f, 40f), "<color=white> GameMode: </color>", this.guiStyle);
                GUI.Label(new Rect(15f, 100f, 200f, 40f), FrameRate.ToString() + "<color=white> FPS </color>");
                GUI.Label(new Rect(15f, 125f, 200f, 40f), Ping.ToString() + "<color=white> PING </color>");

            }

        }

        private void Update()
        {
            FPS = Time.frameCount / Time.time;
            FrameRate = (int)FPS;
            Ping = PhotonNetwork.GetPing();
        }

        public int FrameRate;

        float FPS = 0;


        float Ping = 100;

        public GUIStyle guiStyle = new GUIStyle();

        private readonly XRNode lNode = XRNode.LeftHand;

        private bool sec;

        private bool show;
    }
}
