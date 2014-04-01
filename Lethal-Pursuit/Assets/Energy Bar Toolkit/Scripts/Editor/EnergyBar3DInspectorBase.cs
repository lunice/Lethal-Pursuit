/*
* Copyright (c) Mad Pixel Machine
* http://www.madpixelmachine.com/
*/

using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace EnergyBarToolkit {

public class EnergyBar3DInspectorBase : EnergyBarInspectorBase {

    #region Public Fields
    #endregion

    #region Public Properties
    #endregion

    #region Protected Methods

    protected void SectionPositionAndSize() {
        var script = target as EnergyBar3DBase;

        Section("Position & Size", () => {
            if (MadGUI.Button("Make Pixel-Perfect", Color.yellow)) {
                script.transform.localPosition = MadMath.Round(script.transform.localPosition);
                script.transform.localScale = new Vector3(1, 1, 1);
                EditorUtility.SetDirty(script);
            }

            if (!IsAnchored()) {
                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.LabelField("Anchor");
                if (MadGUI.Button("Create", Color.yellow)) {
                    CreateAnchor();
                }
                EditorGUILayout.EndHorizontal();
            } else {
                var anchor = GetAnchor();
                var serAnchor = new SerializedObject(anchor);
                MadAnchorInspector.DrawInspector(serAnchor);
            }

            EditorGUI.BeginChangeCheck();
            script.pivot = (EnergyBar3DBase.Pivot) EditorGUILayout.EnumPopup("Pivot Point", script.pivot);
            if (EditorGUI.EndChangeCheck()) {
                EditorUtility.SetDirty(script);
            }
            MadGUI.PropertyField(guiDepth, "GUI Depth");
        });
    }

    protected void FieldSprite(SerializedProperty texture, SerializedProperty atlasTexture, string label) {
        if (UseAtlas()) {
            FieldAtlasSprite(atlasTexture, label);
        } else {
            MadGUI.PropertyField(texture, label, MadGUI.ObjectIsSet);
        }
    }

    protected bool UseAtlas() {
        var script = target as EnergyBar3DBase;
        return script.textureMode == EnergyBar3DBase.TextureMode.TextureAtlas;
    }

    #endregion

    #region Public Static Methods
    #endregion

    #region Inner and Anonymous Classes
    #endregion
}

} // namespace