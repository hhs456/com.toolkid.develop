using UnityEngine;
using UnityEditor;
using Toolkid.Core.Attribute;

namespace Toolkid.Attributes {
    // �۩w�q�ݩ�ø�s���A�Ω�ø�s�a���۩w�q���Ҫ��ݩ�
    [CustomPropertyDrawer(typeof(LabelAttribute))]
    public class LabelAttributeDrawer : PropertyDrawer {
        // �bGUI��ø�s�ݩ�
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {            
            var attribute = this.attribute as LabelAttribute;            
            label.text = attribute.label;
            string text = label.text;
            var path = property.propertyPath.Split('.');
            if (path.Length > 2) {                
                if (path[path.Length - 2] == "Array") {
                    // �p�G�O�}�C���� path[path.Length - 1] �� "data[?]"
                    int pos = int.Parse((path[path.Length - 1][5]).ToString());
                    text += " " + pos;
                }
            }
            EditorGUI.PropertyField(position, property, new GUIContent(text, label.tooltip), true);
        }

        // ����ݩʪ�����
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label) {            
            return EditorGUI.GetPropertyHeight(property, label, true);
        }
    }
}
