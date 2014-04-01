﻿#pragma strict

@CustomEditor (PlaygroundBrushPreset)
class PlaygroundBrushPresetInspector extends Editor {
	
	static var brushPreset : SerializedObject;				// PlaygroundBrushPreset
	
	static var presetName : SerializedProperty;				// String
	
	static var texture : SerializedProperty;				// Texture2D
	static var scale : SerializedProperty;					// float
	static var detail : SerializedProperty;					// BRUSHDETAIL
	static var distance : SerializedProperty;				// float
	
	static var spacing : SerializedProperty;				// float
	static var exceedMaxStopsPaint : SerializedProperty; 	// boolean
	
	function OnEnable () {
		brushPreset = new SerializedObject(target);
		texture = brushPreset.FindProperty("texture");
		presetName = brushPreset.FindProperty("presetName");
		scale = brushPreset.FindProperty("scale");
		detail = brushPreset.FindProperty("detail");
		distance = brushPreset.FindProperty("distance");
		spacing = brushPreset.FindProperty("spacing");
		exceedMaxStopsPaint = brushPreset.FindProperty("exceedMaxStopsPaint");
	}
	
	override function OnInspectorGUI () {
		
		brushPreset.Update();
		
		GUILayout.BeginVertical(EditorStyles.textField);
		EditorGUILayout.Space();
		
		// Name
		EditorGUILayout.PropertyField(presetName, new GUIContent(
			"Name", 
			"The name of this brush preset")
		);
		
		EditorGUILayout.Space();
		
		// Texture
		EditorGUILayout.PropertyField(texture, new GUIContent(
			"Brush Shape", 
			"The texture to construct this Brush from")
		);
		
		// Scale
		EditorGUILayout.PropertyField(scale, new GUIContent(
			"Brush Scale", 
			"The scale of this Brush (measured in Units)")
		);
		
		// Detail
		EditorGUILayout.PropertyField(detail, new GUIContent(
			"Brush Detail", 
			"The detail level of this brush")
		);
		
		// Distance
		EditorGUILayout.PropertyField(distance, new GUIContent(
			"Brush Distance", 
			"The distance the brush reaches")
		);
		
		EditorGUILayout.Space();
		
		// Spacing
		EditorGUILayout.PropertyField(spacing, new GUIContent(
			"Paint Spacing", 
			"The required space between the last and current paint position ")
		);
		
		EditorGUILayout.Space();
		
		// Exceeding max stops paint
		EditorGUILayout.PropertyField(exceedMaxStopsPaint, new GUIContent(
			"Exceeding max stops paint", 
			"Should painting stop when paintPositions is equal to maxPositions (if false paint positions will be removed from list when painting new ones)")
		);
		
		EditorGUILayout.Space();
		GUILayout.EndVertical();
		
		brushPreset.ApplyModifiedProperties();
	}
}