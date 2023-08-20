using UnityEngine;

namespace Toolkid.Core.Attribute {
    // 自定義屬性，用於存儲標籤文字
    public class LabelAttribute : PropertyAttribute {
        public string label;

        public LabelAttribute(string label) {
            this.label = label;
        }
    }
}