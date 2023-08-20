using UnityEngine;
using UnityEditor;
using Toolkid.Core.Attribute;

namespace Toolkid.Editor.Attributes {
    // 自定義屬性繪製器，用於繪製帶有自定義標籤的屬性
    [CustomPropertyDrawer(typeof(ArrayLabelAttribute))]
    public class ArrayLabelAttributeDrawer : PropertyDrawer {
        // 在GUI中繪製屬性
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
            var arrayLabelAttribute = (ArrayLabelAttribute)attribute;
            label.text = arrayLabelAttribute.label;

            EditorGUI.PropertyField(position, property, label, true);
        }

        // 獲取屬性的高度
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label) {            
            return EditorGUI.GetPropertyHeight(property, label, true);
        }
    }
}
