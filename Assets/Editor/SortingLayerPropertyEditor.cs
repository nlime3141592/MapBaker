using System.Linq;
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(SortingLayerProperty))]
public class SortingLayerPropertyEditor : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        SerializedProperty valueProp = property.FindPropertyRelative("layerIndex");

        string[] layers = SortingLayer.layers.Select(x => x.name).ToArray();

        valueProp.intValue = EditorGUI.Popup(position, label.text, valueProp.intValue, layers);
    }
}
