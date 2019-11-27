﻿using AdvancedRoadTools.Util;
using ColossalFramework.UI;
using UnityEngine;

namespace AdvancedRoadTools.UI
{
    public class OneRoundButton : UIButton
    {
        public RoadsPanel baseBuildingWindow;
        public override void Start()
        {
            name = "OneRoundButton";
            //text = "O";
            relativePosition = new Vector3((Loader.parentGuiView.fixedWidth / 2f - 490f), (Loader.parentGuiView.fixedHeight / 2f + 370f));
            atlas = SpriteUtilities.GetAtlas(Loader.m_atlasName);
            normalBgSprite = "1Round";
            hoveredBgSprite = "1Round_S";
            focusedBgSprite = "1Round_S";
            pressedBgSprite = "1Round_S";
            size = new Vector2(30f, 30f);
            zOrder = 11;
            eventClick += delegate (UIComponent component, UIMouseEventParameter eventParam)
            {
                if (AdvancedTools.instance.enabled == false)
                {
                    //base.Hide();
                    ToolBase currentTool = ToolsModifierControl.GetCurrentTool<ToolBase>();
                    if (currentTool != null)
                    {
                        NetTool netTool = currentTool as NetTool;
                        if (netTool.m_prefab != null)
                        {
                            AdvancedTools.m_netInfo = netTool.m_prefab;
                        }
                    }
                    ToolsModifierControl.SetTool<DefaultTool>();
                    AdvancedTools.instance.enabled = true;
                    AdvancedTools.m_step = 0;
                    AdvancedTools.rampMode = 2;
                    AdvancedTools.height = 0;
                }
                else
                {
                    ToolsModifierControl.SetTool<DefaultTool>();
                    AdvancedTools.instance.enabled = false;
                    AdvancedTools.m_step = 0;
                    AdvancedTools.height = 0;
                }
            };
        }
        public override void Update()
        {
            base.Update();
            if (!isVisible)
            {
                ToolBase currentTool = ToolsModifierControl.GetCurrentTool<ToolBase>();
                if ((currentTool != null) && (currentTool is NetTool))
                {
                    DebugLog.LogToFileOnly("try show");
                    Show();
                }
            }
            else
            {
                ToolBase currentTool = ToolsModifierControl.GetCurrentTool<ToolBase>();
                if (!((currentTool != null) && (currentTool is NetTool)))
                {
                    Hide();
                }
            }
        }
    }
}
