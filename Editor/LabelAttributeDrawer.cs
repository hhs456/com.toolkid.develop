using UnityEngine;
using UnityEditor;
using Toolkid.Core.Attribute;

namespace Toolkid.Attributes {
    // 自定義屬性繪製器，用於繪製帶有自定義標籤的屬性
    [CustomPropertyDrawer(typeof(LabelAttribute))]
    public class LabelAttributeDrawer : PropertyDrawer {
        // 在GUI中繪製屬性
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {            
            var attribute = this.attribute as LabelAttribute;            
            label.text = attribute.label;
            string text = label.text;
            var path = property.propertyPath.Split('.');
            if (path.Length > 2) {                
                if (path[path.Length - 2] == "Array") {
                    // 如果是陣列元素 path[path.Length - 1] 為 "data[?]"
                    int pos = int.Parse((path[path.Length - 1][5]).ToString());
                    text += " " + pos;
                }
            }
            EditorGUI.PropertyField(position, property, new GUIContent(text, label.tooltip), true);
        }

        // 獲取屬性的高度
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label) {            
            return EditorGUI.GetPropertyHeight(property, label, true);
        }
    }
}
