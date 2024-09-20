using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(MapOrderManager))]
[CanEditMultipleObjects]
public class MapOrderManagerEditor : Editor
{
    private SerializedProperty m_sortingLayerIndex;
    private SerializedProperty m_sortingType;
    private SerializedProperty m_sortingDirection;

    private SerializedProperty m_sortingPositionOffsetZ;
    private SerializedProperty m_sortingPositionDeltaZ;
    private SerializedProperty m_sortingOrderOffset;

    private void OnEnable()
    {
        m_sortingLayerIndex = base.serializedObject.FindProperty("sortingLayerIndex");
        m_sortingType = base.serializedObject.FindProperty("sortingType");
        m_sortingDirection = base.serializedObject.FindProperty("sortingDirection");

        m_sortingPositionOffsetZ = base.serializedObject.FindProperty("sortingPositionOffsetZ");
        m_sortingPositionDeltaZ = base.serializedObject.FindProperty("sortingPositionDeltaZ");
        m_sortingOrderOffset = base.serializedObject.FindProperty("sortingOrderOffset");
}

    public override void OnInspectorGUI()
    {
        base.serializedObject.Update();

        m_sortingLayerIndex.intValue = EditorGUILayout.Popup("Sorting Layer", m_sortingLayerIndex.intValue, SortingLayer.layers.Select(x => x.name).ToArray());

        EditorGUILayout.PropertyField(m_sortingType, new GUIContent("Sorting Type"));
        EditorGUILayout.PropertyField(m_sortingDirection, new GUIContent("Sorting Direction"));

        MapOrderManager.SortingType sType = (MapOrderManager.SortingType)m_sortingType.intValue;

        switch(sType)
        {
            case MapOrderManager.SortingType.SortingOrderNumber:
                EditorGUILayout.PropertyField(m_sortingPositionOffsetZ, new GUIContent("Z-Position"));
                EditorGUILayout.PropertyField(m_sortingOrderOffset, new GUIContent("Sorting Order Offset"));
                break;
            case MapOrderManager.SortingType.PositionZ:
                EditorGUILayout.PropertyField(m_sortingPositionOffsetZ, new GUIContent("Sorting Position Offset Z"));
                EditorGUILayout.PropertyField(m_sortingPositionDeltaZ, new GUIContent("Sorting Position Delta Z"));
                EditorGUILayout.PropertyField(m_sortingOrderOffset, new GUIContent("Sorting Order in Layer"));
                break;
            default:
                UnityEngine.Debug.Assert(false, "Invalid enum value.");
                break;
        }

        base.serializedObject.ApplyModifiedProperties();
    }
}
